using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenaceBehaviour : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed;

    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        float xDir = Random.Range(0.01f, 1.0f);
        float yDir = Random.Range(0.01f, 1.0f);
        float zDir = Random.Range(0.01f, 1.0f);
        Direction = new Vector3(xDir,yDir,zDir);
        transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.transform.name == "BigBox")
        {
            Direction = -Direction;
            transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = Direction * speed * Time.fixedDeltaTime;
    }
}
