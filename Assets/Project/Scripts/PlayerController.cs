using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
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

    public Image vidaAriz;
    public float vidaMaxima;
    public float vidaActual;
    private bool dead = false;
    public GameObject liveID;
    public PlayableDirector director;

    public Image Meds;
    private int numMeds = 0;
    private int maxMeds = 4;
    private float numMedsUI = 0.0f;
    private float maxMedsUI = 100f;

    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        //Recoger Salud
        if (other.CompareTag("Salud"))
        {
            if (numMeds < maxMeds)
            {
                RecogerSalud();
                Destroy(other.gameObject);
            }
        }

        //Pelea
        if (other.CompareTag("ArmaEnemy"))
        {
            vidaActual = vidaActual - 30;
        }

    }

    private void RecogerSalud ()
    {
        numMeds = numMeds + 1;
        numMedsUI = numMedsUI + 25f;
    }

    private void CargarSalud()
    {
        vidaActual = vidaActual + 20;
        numMeds = numMeds - 1;
        numMedsUI = numMedsUI - 25f;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Barra de salud
        vidaAriz.fillAmount = vidaActual / vidaMaxima;
        Meds.fillAmount = numMedsUI / maxMedsUI;

        //F�sica saltos
        isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        //Movimiento
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
            animator.SetBool("Run", true);
        }else animator.SetBool("Run", false);

        // Accion Saltar
        if (Input.GetButtonDown("Jump") && isGounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            animator.SetTrigger("Jump");
        }
        //Accion golpe
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
        //Accion patada
        if (Input.GetButtonDown("Fire2") && animator.GetBool("Run"))
        {
            animator.SetTrigger("FlyingKick");
        }
        //Accion curar
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (numMeds > 0 && vidaActual < vidaMaxima)
            {
                CargarSalud();
            }
        }
        //Contador vida y morir
        if (vidaActual <= 0f && dead == false)
        {
            animator.SetTrigger("Dead");
            director.Play();
            liveID.SetActive(false);
            dead = true;
        }

        //Fisica de movimientos
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
