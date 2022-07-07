using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDown : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody objRigidbody;
    private float outOfView = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        objRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        objRigidbody.AddForce(Vector3.forward * -speed);

        if (transform.position.z < outOfView)
            Destroy(gameObject);
    }
}
