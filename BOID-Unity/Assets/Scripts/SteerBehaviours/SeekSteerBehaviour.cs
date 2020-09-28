using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 desired_velocity = Vector3.zero;

        Vector3 diff = NextWaypoint - actualBoid.transform.position;

        desired_velocity = diff.normalized * maxSpeed;

        return desired_velocity - actualBoid.velocity;
    }
}
