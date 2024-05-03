using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        CharacterMovement(movement);
    }

    void CharacterMovement(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}
