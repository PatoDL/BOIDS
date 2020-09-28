using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerManager : MonoBehaviour
{
    public List<SteerBehaviour> steerBehaviours;
    public float speed;
    public float maxSpeed;

    public Vector3 GetSteeringBehavioursValues(List<BOIDUnit> nearUnits, Vector3 actualVelocity)
    {
        Vector3 toReturn = Vector3.zero;

        //foreach(SteerBehaviour sb in steerBehaviours)
        //{
        //    toReturn += sb.GetForce(nearUnits, actualVelocity, maxSpeed, ) * sb.weight * Time.deltaTime;
        //}

        return toReturn;
    }
}