using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    //
    public float barrelHealth = 10f;
    private bool isBroken = false;
    private int counter = 1;

    //I put the items to store inside of what we want to instanciate 
    public GameObject[] ItemsDeck;
    //Then I will fetch these objects from ýtemsDeck
    private GameObject[] insantanciatedObects;


    
    

 
    void Update()
    {
        ItemDrop();
    }



    public void TakeDamage1(float damage)
    {

        barrelHealth -= damage;
        if(barrelHealth == 0)
        {
            isBroken = true;
        }


    }

    public void ItemDrop()
    {

        //Drop the item until counter become a zero
        if (isBroken == true && counter > 0)
        {

            //Storing the items from inspector inside of instanciate object
            insantanciatedObects = new GameObject[ItemsDeck.Length];

            //I fetching items or objects from Stored list
            for (int i = 0; i < ItemsDeck.Length; i++)
            {
                //Now we can instanciate stored items

                insantanciatedObects[i] = Instantiate(ItemsDeck[i], transform.position, Quaternion.identity) as GameObject;

            }

            //counter become a 0 for this funciton can return once in update
            counter--;
            Destroy(this.gameObject);
        }


    }







}
