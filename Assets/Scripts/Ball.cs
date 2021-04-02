using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddTorque(new Vector3(horizontal, 0, vertical) * ballSpeed);
    }
}
