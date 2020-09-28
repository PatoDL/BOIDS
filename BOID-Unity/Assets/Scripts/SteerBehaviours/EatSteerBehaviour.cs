using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSteerBehaviour : SteerBehaviour
{
    public override Vector3 GetForce(List<BOIDUnit> nearUnits, BOIDUnit actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 desired_velocity = Vector3.zero;

        Vector3 nearestFoodPosition = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        if(food.Count <= 0)
            return Vector3.zero;

        for (int i = 0; i < food.Count; i++)
        {
            float distActualNearest = Vector3.Distance(nearestFoodPosition, actualBoid.transform.position);
            float otherDist = Vector3.Distance(food.ToArray()[i].transform.position, actualBoid.transform.position);

            if (otherDist < distActualNearest)
            {
                nearestFoodPosition = food.ToArray()[i].transform.position;
            }
        }

        Vector3 diff = nearestFoodPosition - actualBoid.transform.position;

        desired_velocity = diff.normalized * maxSpeed;

        return desired_velocity - actualBoid.velocity;


    }
}
