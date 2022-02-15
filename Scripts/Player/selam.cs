using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selam : MonoBehaviour
{
    public float damage1 = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {






            Debug.Log("degdi");


            Vector3 hitDirection = other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 2f, other.transform.position.z + 5f);
            
            
            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthScript>().knockBack(hitDirection);




        }

    }
}
