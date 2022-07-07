using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 10.0f;
    private float zBound = 7.0f;
    private float pickupDuration = 2f;
    public bool hasPickup = false;
    public int HP = 3;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRB.AddForce(Vector3.forward * speed * verticalInput);
        playerRB.AddForce(Vector3.right * speed * horizontalInput);


        ContrainPlayerPosition();
    }


    void ContrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        
        if (transform.position.z >  zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy");
            HP--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            pickup(other);
            HP++;
        }
    }

    void pickup(Collider other)
    {
        Debug.Log("Player collided with pickup");
        Destroy(other.gameObject);
        hasPickup = true;
        StartCoroutine(pickupCountdown());
    }

    IEnumerator pickupCountdown()
    {
        yield return new WaitForSeconds(pickupDuration);
        hasPickup = false;
    }
}
