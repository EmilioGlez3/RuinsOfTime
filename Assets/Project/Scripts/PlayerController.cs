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

    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGounded;

    private Animator animator;
    float movement;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = horizontal + vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
        if (movement != 0f)
        {
            animator.SetBool("Run", true);
        }else animator.SetBool("Run", false);

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
