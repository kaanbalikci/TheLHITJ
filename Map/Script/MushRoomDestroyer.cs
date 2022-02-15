using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomDestroyer : MonoBehaviour
{

    float timer = 5f;
    bool timerControl = true;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerControl)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
                rb.constraints &= ~RigidbodyConstraints.FreezeRotationX;
                if (timer<=-2)
                {
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    timerControl = false;
                }
                
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rock" && timer > 0)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "tree" && timer > 0)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "wood" && timer > 0)
        {
            Destroy(gameObject);
        }
    }
}
