using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 desired_velocity = Vector3.zero;

        for (int i = 0; i < Menace.Count; i++)
        {
            Vector3 diff = actualBoid.transform.position - Menace[i].transform.position;
            float dist = Vector3.Distance(actualBoid.transform.position, Menace[i].transform.position);

            if (dist < radius)
            {
                Vector3 desiredPosition = Menace[i].transform.position - actualBoid.transform.position;

                desired_velocity = (desiredPosition.normalized * maxSpeed) - actualBoid.velocity;

                return desired_velocity * -1.0f;
            }
        }

        return Vector3.zero;
    }
}
