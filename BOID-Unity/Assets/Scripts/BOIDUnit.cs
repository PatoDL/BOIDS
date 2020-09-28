using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDUnit : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public Vector3 velocity;
    public SphereCollider cohesionTrigger;

    public GameObject MenacePF;

    public float eatenFoodCount;

    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(1, 360);
        speed = Random.Range(5, 8);
        velocity = /*new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Random.Range(-1, 1)) * speed*/ Vector3.zero;
        eatenFoodCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocity * Time.deltaTime;   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "BigBox")
        {
            velocity = -velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Food")
        {
            BOIDManager.Get().FoodList.Remove(other.gameObject);
            Destroy(other.gameObject);
            eatenFoodCount++;
            if (eatenFoodCount >= 5)
                TransformIntoMenace();
        }
    }

    public Vector3 LimitVelocity(Vector3 actualV, float limit)
    {
        if (actualV.magnitude > maxSpeed)
        {
            actualV /= actualV.magnitude / limit;
        }

        return actualV;
    }

    private void TransformIntoMenace()
    {
        GameObject g = Instantiate(MenacePF);
        g.transform.position = transform.position;
        BOIDManager.Get().MenaceList.Add(g);
        BOIDManager.Get().BoidList.Remove(this);
        Destroy(this.gameObject);
    }
}
