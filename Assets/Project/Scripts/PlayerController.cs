using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Playables;//Para Timeline

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        animator.SetFloat("Direction", Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
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
        }
    }
}
