using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    private float turnAmount;
    private float forwardAmount;
    private bool isBraking;
    CarController carController;
    // Start is called before the first frame update
    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    private void FixedUpdate()
    {
        turnAmount = Input.GetAxis("Horizontal");
        forwardAmount = Input.GetAxis("Vertical");
        isBraking = Input.GetButton("Jump");
        carController.Drive(forwardAmount,turnAmount);
        carController.BrakeCar(isBraking);
    }
}
