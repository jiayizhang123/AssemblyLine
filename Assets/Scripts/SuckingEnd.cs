using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingEnd : MonoBehaviour
{
    public GameObject pickedObject;
    public AudioSource suckingSound;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Picking()
    { //picking a product, and stick it to the arm
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pickedObject.transform.position = newPos;
        rb = pickedObject.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
    }

    public void Droping()
    { // reset the physics of the product
        rb.useGravity = true;
        rb.freezeRotation = false;
        Debug.Log("droped");
    }

    private void OnTriggerEnter(Collider other)
    { //check if the collider is the product
        if (other.gameObject.CompareTag("Product"))
        {
            Debug.Log("Picked");
            suckingSound.Play();
            pickedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Product"))
        {
            pickedObject = null;
            Destroy(other,3f);
        }
    }
}
