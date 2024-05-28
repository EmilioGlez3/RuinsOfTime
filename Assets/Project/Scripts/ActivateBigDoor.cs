using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateBigDoor : MonoBehaviour
{
    private GameObject Activate1 = null;
    public GameObject cam;
    public GameObject bigDoor;

    private Vector3 DoorPosition;
    public GameObject TargetPosition;
    public float speed = 1f;
    private bool door = false;

    //Audio
    public AudioSource audioSource;
    private bool audi = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Activate1 == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                Activate1 = other.gameObject;
                cam.GetComponent<CinemachineVirtualCamera>().Priority = 11;
                door = true;
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
            DoorPosition = TargetPosition.transform.position - bigDoor.transform.position;
            if (DoorPosition.y < -0.1)
            {
                bigDoor.transform.position += DoorPosition.normalized * speed * Time.deltaTime;
            }
            else
            {
                cam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
                door = false;
                bigDoor.SetActive(false);
                if (audi == true)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
