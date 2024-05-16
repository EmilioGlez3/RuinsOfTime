using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        /*if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetFloat("Direction", -1.0f);
        }else if (Input.GetAxis("Horizontal")  > 0.1)
        {
            animator.SetFloat("Direction", 1.0f);
        }else animator.SetFloat("Direction", 0.0f);*/

    }
}
