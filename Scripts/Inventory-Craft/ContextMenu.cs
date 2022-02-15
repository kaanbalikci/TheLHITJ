using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public static ContextMenu ConMenu;


    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;

    public void Awake()
    {
        ConMenu = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the game object
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        if (results.Count > 0)
        {
            
            if (results[0].gameObject.name == "Image")
            {
                Inventory.inv.armorNO = 1;
          
            }
            else
            {
                Inventory.inv.armorNO = 0;
           
            }


            if (results[0].gameObject.name == "Helmet")
            {
                Inventory.inv.isHelmet = true;
                Inventory.inv.holdArmorNo = 1;
                
            }
            else if (results[0].gameObject.name == "Chest")
            {
                Inventory.inv.isChest = true;
                Inventory.inv.holdArmorNo = 2;
              
            }
            else if (results[0].gameObject.name == "Pant")
            {
                Inventory.inv.isPant = true;
                Inventory.inv.holdArmorNo = 3;
            
            }
            else if (results[0].gameObject.name == "Boots")
            {
                Inventory.inv.isBoots = true;
                Inventory.inv.holdArmorNo = 4;
            }
            else
            {
                Inventory.inv.isHelmet = false;
                Inventory.inv.isChest = false;
                Inventory.inv.isPant = false;
                Inventory.inv.isBoots = false;
                

            }


        }


      
    }
}
