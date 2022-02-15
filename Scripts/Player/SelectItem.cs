using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private GameObject ItemNameObj;
    [SerializeField] private Text ItemNameText;
    [SerializeField] private Camera cam1;

    public static bool canPick;
    RaycastHit hit;

    void Update()
    {
        //raycast is going center of screen
        Ray ray = cam1.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //show item name in screen
        if (Physics.Raycast(ray, out hit,10f) )
        {
            if(hit.collider.GetComponent<ThisItem>())
            {
                ItemNameObj.SetActive(true);
                ItemNameText.text = hit.collider.GetComponent<ThisItem>().itemName;
                canPick = true;
            }
            else
            {
                ItemNameObj.SetActive(false);
                canPick = false;
            }          
        }
        else
        {
            ItemNameObj.SetActive(false);
            canPick = false;
        }

    }
}


/*        itemList.Add(new Item(1, "Axe", "Weapon", Resources.Load<Sprite>("1"), 0, 1, true));
        itemList.Add(new Item(2, "Revolver", "Weapon", Resources.Load<Sprite>("2"), 0, 1, true));
        itemList.Add(new Item(3, "Shogun", "Weapon", Resources.Load<Sprite>("3"), 0, 1, true));
        itemList.Add(new Item(4, "Meat", "Food", Resources.Load<Sprite>("4"), 0, 10, false));
        itemList.Add(new Item(5, "Apple", "Food", Resources.Load<Sprite>("5"), 0, 20, false));
        itemList.Add(new Item(6, "Water", "Water", Resources.Load<Sprite>("6"), 0, 1, false));
        itemList.Add(new Item(7, "Leather", "Craft", Resources.Load<Sprite>("7"), 0, 10, false));
        itemList.Add(new Item(8, "Wood", "Craft", Resources.Load<Sprite>("8"), 0, 25, false));
        itemList.Add(new Item(9, "Rock", "Craft", Resources.Load<Sprite>("9"), 0, 50, false));
        itemList.Add(new Item(10, "Stick", "Craft", Resources.Load<Sprite>("10"), 0, 50, false));
        itemList.Add(new Item(11, "Rope", "Craft", Resources.Load<Sprite>("11"), 0, 10, false));
        itemList.Add(new Item(12, "Gunpowder", "Craft", Resources.Load<Sprite>("12"), 0, 50, false));
        itemList.Add(new Item(13, "Bullet", "None", Resources.Load<Sprite>("13"), 0, 20, false));*/