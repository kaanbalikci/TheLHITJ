using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController: MonoBehaviour
{
public float hiz;
public Rigidbody rb;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.forward * hiz * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {

            rb.velocity = Vector3.left * hiz * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.W))
        {

            rb.velocity = Vector3.right * hiz * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {

            rb.velocity = Vector3.back * hiz * Time.deltaTime;
        }
    }
}