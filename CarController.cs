using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider FLW, FRW, RLW, RRW;
    public Transform FLT, FRT, RLT, RRT;
    public float maxSteerAngle = 30;//degrees
    public float motorForce = 50;



    public void Drive(float forwardAmount,float turnAmount)
    {
        //get input


        //steer wheels
        steeringAngle = maxSteerAngle * turnAmount;
        //from wheel drive
        FLW.steerAngle = steeringAngle;
        FRW.steerAngle = steeringAngle;

        //accelerate
        FLW.motorTorque = motorForce * forwardAmount;
        FRW.motorTorque = motorForce * forwardAmount;

        //update wheel position
        UpdateWheelPoses(FLW, FLT);
        UpdateWheelPoses(FRW, FRT);
        UpdateWheelPoses(RLW, RLT);
        UpdateWheelPoses(RRW, RRT);

    }

    public void BrakeCar(bool isBraking)
    {

        if (isBraking)
        {
            Debug.Log("Stopping!");
            FLW.motorTorque = 0;
            FRW.motorTorque = 0;
            FLW.brakeTorque = motorForce * 5;//need to appy a lot of force in other direction to stop
            FRW.brakeTorque = motorForce * 5;
        }
        else
        {
            FLW.brakeTorque = motorForce * 0;//need to appy a lot of force in other direction to stop
            FRW.brakeTorque = motorForce * 0;

        }
    }
    //helper method from above
    private void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;

    }


}
