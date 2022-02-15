using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDestoreyer : MonoBehaviour
{
    float timer = 5f;
    bool timerControl = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerControl)
        {
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                timerControl = false;  
            }
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="rock" && timer > 0)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "tree" && timer > 0)
        {
            Destroy(gameObject);
        }
    }
}
