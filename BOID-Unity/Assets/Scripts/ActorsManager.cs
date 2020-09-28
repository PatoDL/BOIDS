using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorsManager : MonoBehaviour
{
    public GameObject MenacePrefab;
    public GameObject FoodPrefab;

    public float FoodSpawnTime;
    private float FoodSpawnTimeHandler;

    public float MenaceSpawnTime;
    private float MenaceSpawnTimeHandler;

    public BoxCollider BigBoxCollider;
    private Bounds BoxBounds;
    // Start is called before the first frame update
    void Start()
    {
        FoodSpawnTimeHandler = FoodSpawnTime;
        MenaceSpawnTimeHandler = MenaceSpawnTime;
        BoxBounds = BigBoxCollider.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        FoodSpawnTime -= Time.deltaTime;
        MenaceSpawnTime -= Time.deltaTime;

        if (FoodSpawnTime <= 0.0f)
        {
            GameObject g = Instantiate(FoodPrefab);
            float xPos = Random.Range(BoxBounds.min.x, BoxBounds.max.x);
            float zPos = Random.Range(BoxBounds.min.z, BoxBounds.max.z);
            float yPos = BoxBounds.max.y;
            g.transform.position = new Vector3(xPos,yPos,zPos);
            BOIDManager.Get().FoodList.Add(g);
            FoodSpawnTime = FoodSpawnTimeHandler;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject g = Instantiate(MenacePrefab);
            float xPos = Random.Range(BoxBounds.min.x, BoxBounds.max.x);
            float zPos = Random.Range(BoxBounds.min.z, BoxBounds.max.z);
            float yPos = Random.Range(BoxBounds.min.y, BoxBounds.max.y);
            g.transform.position = new Vector3(xPos, yPos, zPos);
            BOIDManager.Get().MenaceList.Add(g);
        }
    }
}
