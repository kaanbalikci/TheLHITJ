using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{
    public GameObject PushE;
    private bool playerInSight;

    private void Update()
    {
        
        if(playerInSight == true && Input.GetKeyDown(KeyCode.E))
        {
            if(thirstSystem.thirstSystemScript.currentThirst < 100)
            {

                thirstSystem.thirstSystemScript.currentThirst += 5f;

            }

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInSight = true;
            PushE.SetActive(true);

           
        } 

      
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInSight = false;
            PushE.SetActive(false);
            Debug.Log("as");
        }
    }

  



}
