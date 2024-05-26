using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TakeObject : MonoBehaviour
{

    public GameObject handPoint;
    private GameObject pickedObject = null;

    public Animator animator;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                animator.SetTrigger("Take");
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
    
    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey(KeyCode.R))
            {
                animator.SetTrigger("Leave");
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }
}
