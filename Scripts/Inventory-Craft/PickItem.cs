using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private Camera cam1;
    public GameObject Item;
    RaycastHit hit2;

    public static bool pick;
    public static GameObject y;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam1.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (SelectItem.canPick == true)
        {
            if (Physics.Raycast(ray, out hit2))
            {
                if (hit2.collider.gameObject.tag == "Select" || hit2.collider.gameObject.tag == "rock" || hit2.collider.gameObject.tag == "wood")
                {
                    //use Y and ITEM in inv script 
                    y = hit2.collider.gameObject;
                    Item = hit2.collider.gameObject;
                }
                else
                {
                    y = null;
                    Item = null;
                }
            }



            //if press E take item and destroy
            if (Input.GetKeyDown(KeyCode.E) && Inventory.inv.hammerOpen == false)
            {
                Destroy(Item);
                Item = null;
                pick = true;
            }
        }
        else
        {
            y = null;
            Item = null;
        }
    }
}
