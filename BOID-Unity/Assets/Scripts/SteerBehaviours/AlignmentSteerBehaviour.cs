using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 desired_velocity = Vector3.zero;
        int nearUnitsCount = 0;

        foreach (BOIDUnit b in nearUnits)
        {
            if (actualBoid == b)
                continue;

            Vector3 diff = actualBoid.transform.position - b.transform.position;
            float dist = diff.magnitude;

            if (dist < radius)
            {
                nearUnitsCount++;
                desired_velocity += b.velocity;
            }
        }

        if (nearUnitsCount > 0)
        {
            desired_velocity /= nearUnitsCount;
            return desired_velocity - actualBoid.velocity;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
