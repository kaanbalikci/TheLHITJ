using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{

    public float AIHealth1;
   
    private float counter = 0.1f;
    private float deadcounter = 0.1f;

    [SerializeField]
    //I put the items to store inside of what we want instanciate 
    public GameObject[] ItemsDeck;
    //Then I will fetch these objects from ýtemsDeck
    private GameObject[] insantanciatedObects;

    [HideInInspector] public bool hit;
    [HideInInspector] public bool Dead;

    private void Start()
    {
       
    }

    void Update()
    {
        Death();
        ItemDrop();
        
        
    }
   


  //taking damage by guns OR axe
   public void TakeDamage (float amount)
    {

        AIHealth1 -= amount;
        hit = true;
        if(AIHealth1 <= 0f)
        {
           
            Death();

        }



    }




   public void Death()
    {
        Dead = false;
        
        if (AIHealth1 <= 0)
        {

            if(gameObject.tag == "deer" && deadcounter > 0)
            {
                
                GameObject.Find("AIStartSpawner").GetComponent<AIController>().numberOfDeer -= 1;
                deadcounter--;
            }
            if (gameObject.tag == "rabbit" && deadcounter > 0)
            {

                GameObject.Find("AIStartSpawner").GetComponent<AIController>().numberOfRabbit -= 1;
                deadcounter--;
            }
            if (gameObject.tag == "wolf" && deadcounter > 0)
            {

                GameObject.Find("AIStartSpawner").GetComponent<AIController>().numberOfWolf -= 1;
                deadcounter--;
            }
            if (gameObject.tag == "bear" && deadcounter > 0)
            {

                GameObject.Find("AIStartSpawner").GetComponent<AIController>().numberOfBear -= 1;
                deadcounter--;
            }
            if (gameObject.tag == "boar" && deadcounter > 0)
            {

                GameObject.Find("AIStartSpawner").GetComponent<AIController>().numberOfBoar -= 1;
                deadcounter--;
            }
            Dead = true;
        }

        
    }

   public void ItemDrop()
    {
        
        //Drop the item until counter become a zero
        if (Dead == true && counter > 0)
        {
            //Storing the items from inspector inside of instanciate object
            insantanciatedObects = new GameObject[ItemsDeck.Length];

            //I fetching items or objects from Stored list
            for (int i = 0; i < ItemsDeck.Length; i++)
            {
                //Now we can instanciate stored items

                insantanciatedObects[i] = Instantiate(ItemsDeck[i], transform.position, Quaternion.identity) as GameObject;
                
            }

            //counter become a 0 for this funciton can return once
            counter--;
        }


    }
}
