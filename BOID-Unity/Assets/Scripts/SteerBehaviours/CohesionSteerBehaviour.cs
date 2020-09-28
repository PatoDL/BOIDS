using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 desired_velocity = Vector3.zero;

        float nearUnitsCount = 0;

        if (nearUnits.Count > 0)
        {
            foreach (BOIDUnit b in nearUnits)
            {
                if (b == actualBoid)
                    continue;

                var diff = actualBoid.transform.position - b.transform.position;
                float dist = diff.magnitude;

                if (dist < radius)
                {
                    nearUnitsCount++;
                    desired_velocity += b.transform.position;
                }
            }
            
        }

        if (nearUnitsCount > 0)
        {
            desired_velocity /= nearUnitsCount;
            //desired_velocity -= actualBoid.transform.position;
            //desired_velocity = desired_velocity.normalized * maxSpeed;
            return desired_velocity /*- actualBoid.velocity*/;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
