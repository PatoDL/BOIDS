using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationSteerBehaviour : SteerBehaviour
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

                Vector3 diff = actualBoid.transform.position - b.transform.position;
                float dist = /*diff.magnitude*/ Vector3.Distance(actualBoid.transform.position, b.transform.position);

                

                if (dist < radius)
                {
                    nearUnitsCount++;
                    if(dist > 0)
                        desired_velocity += diff.normalized / /*Mathf.Pow(dist, 2)*/ dist;
                }
            }

           
        }
        if (nearUnitsCount > 0)
        {
            return desired_velocity * maxSpeed;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
