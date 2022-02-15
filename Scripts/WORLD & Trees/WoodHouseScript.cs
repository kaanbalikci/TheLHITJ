using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHouseScript : MonoBehaviour
{
    public static WoodHouseScript InCeilingRange;
   [HideInInspector] public bool houseInSightRange;
  

    private void Awake()
    {
        InCeilingRange = this;
    }
    void Start()
    {
        houseInSightRange = false;
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        //if player enter the building disable freezing 

    if(other.gameObject.tag == "Player")
        {
            houseInSightRange = true;
          
        }
       

    }
    
    private void OnTriggerExit(Collider other)
    {

        houseInSightRange = false;
      
    }
    
}
