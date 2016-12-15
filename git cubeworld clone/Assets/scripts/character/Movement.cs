using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 20;
    public float rotatingSpeed = 13;

    private Transform childTransform;
    private bool isWalking = false;
    private Animator animator;
    private CombatScript combatScript;

    void Start() {
        childTransform = gameObject.transform.GetChild(0).transform;
        animator = GetComponent<Animator>();
        combatScript = GetComponent<CombatScript>();
    }

    void Update() {
        //change character forward to camera forward
        transform.forward = Vector3.Slerp(transform.forward, new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z), rotatingSpeed * Time.deltaTime);

        //is character walking
        isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        if(isWalking) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("run")) {
                animator.Play("run", 0);
                Debug.Log("to run");
            }

            //rotate character
            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0) {
                //forward
                //Debug.Log("forward");
                Vector3 newDir = new Vector3(0, 0, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0) {
                //backward
                //Debug.Log("backward");
                Vector3 newDir = new Vector3(0, 180, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0) {
                //left
                //Debug.Log("left");
                Vector3 newDir = new Vector3(0, 270, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0) {
                //right
                //Debug.Log("right");
                Vector3 newDir = new Vector3(0, 90, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0) {
                //top left
                //Debug.Log("top left");
                Vector3 newDir = new Vector3(0, 315, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0) {
                //top right
                //Debug.Log("top right");
                Vector3 newDir = new Vector3(0, 45, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0) {
                //backward left
                //Debug.Log("backward left");
                Vector3 newDir = new Vector3(0, 225, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }
            else if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0) {
                //backward right
                //Debug.Log("backward right");
                Vector3 newDir = new Vector3(0, 135, 0);
                childTransform.localEulerAngles = Vector3.Slerp(childTransform.localEulerAngles, newDir, rotatingSpeed * Time.deltaTime);
            }

            //translate
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0, Input.GetAxis("Vertical") * movementSpeed);
            transform.Translate(moveDirection * Time.deltaTime);
        }
        else{
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("idle")) {
                animator.Play("idle", 0);
                Debug.Log("to idle");
            }
        }
    }
}
