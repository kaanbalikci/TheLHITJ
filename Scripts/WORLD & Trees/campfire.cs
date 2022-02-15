using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour
{

   


    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {

        //destroy campfire after 10 min
        Destroy(this.gameObject, 600f);

    }
    private void OnTriggerStay(Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            
                FreezingSystem.freezeSystem.increase(0.05f);
              
            
        }   
    }
}
   

