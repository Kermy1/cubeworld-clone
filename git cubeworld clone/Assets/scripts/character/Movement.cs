using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour {
    public Transform cameraTransform;
    public float movementSpeed = 20;
    public float rotatingSpeed = 10;
    
    private Vector3 cameraAngle;
    private Vector3 moveDirection;
    private Vector3 rotation;

	void Start () {
        rotation = transform.eulerAngles;
    }
	
	void Update () {
        //if input
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0) {
            //rotate

            //Vector3 targetDir = new Vector3(0, cameraTransform.eulerAngles.y, 0);
            //Vector3 newDirection = Vector3.Slerp(transform.eulerAngles, targetDir, Time.deltaTime * rotatingSpeed); //360 -> 0 & 0 -> 360 geeft de rare draai           
            //transform.eulerAngles = newDirection;

            transform.RotateAround(transform.eulerAngles, Vector3.up, cameraTransform.eulerAngles.y * Time.deltaTime);

            //Debug.Log(newDirection.ToString());

            //translate
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed);
            transform.Translate(moveDirection * Time.deltaTime);
        }
    }
}
