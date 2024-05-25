using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Playables;//Para Timeline

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    /*private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }*/

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        //animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        //animator.SetFloat("Direction", Input.GetAxis("Horizontal"));

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("FlyingKick");
            animator.SetBool("Action", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Action", true);
        }else if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("Action", false);
        }*/
    }
}
