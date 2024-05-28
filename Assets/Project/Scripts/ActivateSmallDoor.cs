using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateSmallDoor : MonoBehaviour
{
    private GameObject Activate = null;
    public GameObject cam;
    public GameObject smallDoor;

    public GameObject orbe;
    public GameObject lights;

    private Vector3 DoorPosition;
    public GameObject TargetPosition;
    public float speed = 1f;
    private bool door = false;

    public Animator animator;

    //Audio
    public AudioSource audioSource;
    private bool audi = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Activate == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                Activate = other.gameObject;
                cam.GetComponent<CinemachineVirtualCamera>().Priority = 11;
                door = true;
                orbe.SetActive(false);
                lights.SetActive(true);
                animator.SetTrigger("Leave");
            }
        }
    }

    private void FixedUpdate()
    {
        if (door)
        {
            if (audi == false)
            {
                audioSource.Play();
                audi = true;
            }
            DoorPosition = TargetPosition.transform.position - smallDoor.transform.position;
            if (DoorPosition.y < -0.1)
            {
                smallDoor.transform.position += DoorPosition.normalized * speed * Time.deltaTime;
            }
            else
            {
                cam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
                door = false;
                smallDoor.SetActive(false);
                if (audi == true)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
