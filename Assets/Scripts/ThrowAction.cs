using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowAction : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public GameObject objectToThrow;

    [Header("Settings")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public bool readyToThrow;

    private void Awake()
    {
        readyToThrow = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow) {
            Throw();  
        }
    }

    private void Throw() {
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        Vector3 attackP = rb.position + rb.transform.right;

        GameObject newObj = Instantiate(objectToThrow, attackP, rb.rotation * Quaternion.Euler(0, 0, 90)); //* Quaternion.Euler(0,0,90)

        Vector3 forceToAdd = cam.forward * throwForce + transform.up * throwUpwardForce;

        newObj.GetComponent<Rigidbody>().AddForce(forceToAdd,ForceMode.Impulse);
    }

    public void toggleReady() {
        readyToThrow = !readyToThrow;
    }
}
