using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteerBehaviour : MonoBehaviour
{
    [UnityEngine.Range(0, 20)]
    public float weight;

    public float radius;

    public abstract Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> foodList, List<GameObject> menaceList, Vector3 NextWaypoint);
}
