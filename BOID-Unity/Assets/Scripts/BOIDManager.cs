using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDManager : MonoBehaviour
{
    public static BOIDManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public static BOIDManager Get()
    {
        return Instance;
    }

    public GameObject BOIDPF;
    public float spawnTime;
    public float spawnTimer;

    [Header("Lists")]
    public List<BOIDUnit> BoidList = new List<BOIDUnit>();
    public List<SteerBehaviour> SteerBehaviours = new List<SteerBehaviour>();
    public List<GameObject> FoodList = new List<GameObject>();
    public List<GameObject> MenaceList = new List<GameObject>();
    public Transform WaypointsParent;
    public List<Vector3> WaypointsList = new List<Vector3>();
    public Vector3 ActualWaypoint;

    private int WaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTime;
        for (int i = 0; i < WaypointsParent.childCount; i++)
        {
            WaypointsList.Add(WaypointsParent.GetChild(i).position);
        }

        ActualWaypoint = WaypointsList.ToArray()[WaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //spawnTimer -= Time.deltaTime;
        //if(spawnTimer < 0f)
        //{
        //    SpawnBOID();
        //    spawnTimer = spawnTime;
        //}

        if(Input.GetKeyDown(KeyCode.B))
            SpawnBOID();

        foreach (BOIDUnit b in BoidList)
        {
            foreach (SteerBehaviour s in SteerBehaviours)
            {
                b.velocity += s.GetForce(BoidList, b, b.maxSpeed, FoodList, MenaceList, ActualWaypoint) * s.weight * Time.deltaTime;
                b.velocity = b.LimitVelocity(b.velocity, b.maxSpeed);
                
                if (Vector3.Distance(b.transform.position, ActualWaypoint) < 1f)
                {
                    WaypointIndex++;
                    if (WaypointIndex >= WaypointsList.Count)
                        WaypointIndex = 0;
                    ActualWaypoint = WaypointsList.ToArray()[WaypointIndex];
                }
            }
            b.transform.position += b.velocity * Time.deltaTime;
        }
    }

    void SpawnBOID()
    {
        GameObject g = Instantiate(BOIDPF, Vector3.zero, Quaternion.identity);
        BoidList.Add(g.GetComponent<BOIDUnit>());
    }
}
