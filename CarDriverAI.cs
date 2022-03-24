using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriverAI : MonoBehaviour
{
    [SerializeField] Transform targetPosTransform;
    CarController carController;
    Vector3 targetPosition;

    [SerializeField] Transform[] waypoints;
    public int index = 0;

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition(waypoints[index]);
        float forwardAmount = 0f;
        float turnAmount = 0f;


        float reachTargetDistance = 7f;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        float Speed = GetComponent<Rigidbody>().velocity.magnitude;

        if(distanceToTarget > reachTargetDistance)
        {
            Vector3 dirToMovePosition = (targetPosition - transform.position).normalized;


            float dot = Vector3.Dot(transform.forward, dirToMovePosition);
            if (dot > 0){forwardAmount = 1f;}
            else{forwardAmount = -1f;}

            float angletodir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);
            Debug.Log(dirToMovePosition);
            if (angletodir > 10){turnAmount = 1f;}
            else if (angletodir <-10){turnAmount = -1f;}
            carController.Drive(forwardAmount, turnAmount);
        }
        else
        {
            if (index >= waypoints.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        


       
        
    }

    public void SetTargetPosition(Transform newTarget)
    {
        targetPosition=newTarget.position;
    }
}
