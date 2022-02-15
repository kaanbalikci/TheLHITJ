using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingItem : MonoBehaviour
{
    public static BuildingItem BuildingI;
    RaycastHit Hit;
    public GameObject instantiateObj;
    public Material orjMat;
    public float Y;

    private bool canBuild = true;

    public void Awake()
    {
        BuildingI = this;
    }

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject != null && !other.gameObject.CompareTag("Ground"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            canBuild = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material = orjMat;
        canBuild = true;
    }

    void Update()
    {
        if(Inventory.inv.inventoryOpen == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit, 500f, (1 << 6)))
            {
                transform.position = new Vector3(Hit.point.x, Hit.point.y + Y, Hit.point.z);
            }

            if (Input.GetMouseButton(0) && canBuild == true)
            {
                if (Inventory.inv.BuildId == 0)
                {
                    for (int i = 0; i < Inventory.inv.slotsNumber; i++)
                    {
                        if (Inventory.inv.ourInventory[i].id == 21)
                        {
                            Instantiate(instantiateObj, transform.position, transform.rotation);
                            Inventory.inv.ourInventory[i] = ItemData.itemList[0];
                        }
                    }
                }
                else if (Inventory.inv.BuildId == 1)
                {
                    for (int i = 0; i < Inventory.inv.slotsNumber; i++)
                    {
                        if (Inventory.inv.ourInventory[i].id == 22)
                        {
                            Instantiate(instantiateObj, transform.position, transform.rotation);
                            Inventory.inv.ourInventory[i] = ItemData.itemList[0];
                        }
                    }
                }
                else if (Inventory.inv.BuildId == 2)
                {
                    for (int i = 0; i < Inventory.inv.slotsNumber; i++)
                    {
                        if (Inventory.inv.ourInventory[i].id == 23)
                        {
                            Instantiate(instantiateObj, transform.position, transform.rotation);
                            Inventory.inv.ourInventory[i] = ItemData.itemList[0];
                        }
                    }
                }
                else if (Inventory.inv.BuildId == 3)
                {
                    for (int i = 0; i < Inventory.inv.slotsNumber; i++)
                    {
                        if (Inventory.inv.ourInventory[i].id == 24)
                        {
                            Instantiate(instantiateObj, transform.position, transform.rotation);
                            Inventory.inv.ourInventory[i] = ItemData.itemList[0];
                        }
                    }
                }


            }
        }
        

 

        if(Inventory.inv.hammerOpen == false)
        {
            Destroy(gameObject);
        }

    }

    public void BuildDeath()
    {
        Destroy(gameObject);
    }
}
