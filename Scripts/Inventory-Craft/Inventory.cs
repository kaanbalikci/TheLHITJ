using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public List<Item> ourInventory = new List<Item>();

    public List<Item> draggedItem = new List<Item>();

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };

    public static Inventory inv;
    
    public Camera cam2;

    public GameObject bulletCount;

    //bullet
    public int sgBulletCount = 0;
    public int revoBulletCount = 0;
    public int revoAmmo = 0;
    public int sgAmmo = 0;

    // Right Click menu
    public int armorNO;
    public bool isHelmet;
    public bool isChest;
    public bool isPant;
    public bool isBoots;
    public bool armorCheck;
    //

    // build inputs
    public GameObject buildUI;
    public GameObject[] buildSlots;
    public GameObject[] buildItemsPreview;
    public int BuildId = 0;
    private bool buildMenuOpen;

    //DROP
    public GameObject[] dropItems;
    public Transform DropPoint;

    //
    public int slotsNumber;

    public GameObject x;
    public int n;
    public int a;
    public int b;
    public int hotbarSizeHolder;

    public int holdSlotNumber;

    public int rest;
    public bool shift;
    public bool ctrl;
    public bool isOpen;
    public bool inventoryOpen;
    public bool isHotbarOpen;
    public bool canConsume;


    //weapon open checker
    public bool axeOpen;
    public bool shotgunOpen;
    public bool revolverOpen;
    public bool torchOpen;
    public bool hammerOpen;
    public bool click;


    public int slotTemporary;

    //Context Menu
    public GameObject ContextMenuArmor;
    public GameObject ContextMenuDrink;
    public GameObject ContextMenuEat;
    public GameObject ContextMenuNormal;
    public GameObject ContextMenuUnequip;
    public GameObject ContextMenuDelete;
    public int holdArmorNo;
    /////////////////

    public Vector3 mousePos;
    public GameObject Camera;
    public GameObject InventorySlots;
    public GameObject[] HotbarSlots;
    public GameObject[] HotbarItems;
    public GameObject player;
    public Image[] slot;
    public Sprite[] slotSprite;
    public Text[] stackText;
    public int[] slotStack;
    public Image HelmetSlot, ChestSlot, PantSlot, BootsSlot;

    //CRAFT INPUTS----------------------------
    public Image[] slotInCraft;
    public Sprite[] slotInCraftSprite;

    public Image craftedItem;
    public Sprite craftedItemSprite;

    public int craftableItemID;
    public int firstCraftableItemID;
    public int lastCraftableItemID;

    public Text craftedItemName;
    public Text[] craftingText;

    public bool craft;
    //-------------------------------------------


    //health script
    private HealthScript HSript;

    private void Awake()
    {
        HSript = player.GetComponent<HealthScript>();
        inv = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        ourInventory[0] = ItemData.itemList[1];
        slotStack[0] = 1;
        ourInventory[1] = ItemData.itemList[2];
        slotStack[1] = 1;
        ourInventory[2] = ItemData.itemList[3];
        slotStack[2] = 1;
        ourInventory[3] = ItemData.itemList[18];
        slotStack[3] = 15;
        ourInventory[4] = ItemData.itemList[20];
        slotStack[4] = 15;

        firstCraftableItemID = 16;
        lastCraftableItemID = 41;
        craftableItemID = firstCraftableItemID;


    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        closeInventory();
        Hotbar();
        rightClickMenu();     
        BuildItem();

        //bullet counter
        //revo
        if (Gun.revoReload == true)
        {
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 18)
                {
                    if(revoAmmo < 6) 
                    {
                        if (slotStack[i] + revoAmmo <= 6)
                        {
                            revoAmmo += slotStack[i];
                            revoBulletCount = 0;
                            ourInventory[i] = ItemData.itemList[0];
                        }
                        else if (slotStack[i] + revoAmmo > 6)
                        {
                            if (revoAmmo > 0)
                            {
                                slotStack[i] = slotStack[i] - (6 - revoAmmo);
                                revoAmmo = 6;
                            }
                            else if(revoAmmo == 0)
                            {
                                revoAmmo = 6;
                                slotStack[i] -= 6;
                            }
                            
                        }
                    }
                    
                    
                }
            }
            Gun.revoReload = false;
        }

        if (Gun.pistolFire == true)
        {
            if (revoAmmo > 0)
            {
                revoAmmo -= 1;
            }

            Gun.pistolFire = false;
        }

        for (int i = 0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == 18)
            {
                revoBulletCount = slotStack[i];
            }
        }
        //
        //shotgun
        for (int i = 0; i < slotsNumber; i++)
        {
            if(ourInventory[i].id == 20)
            {
                sgBulletCount = slotStack[i];
            }
        }

        

        if (shotgunScript.sgReload == true)
        {
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 20)
                {

                    if (slotStack[i] == 1)
                    {
                        ourInventory[i] = ItemData.itemList[0];
                        sgBulletCount = 0;
                    }
                    else if (slotStack[i] > 1)
                    {
                        slotStack[i]--;
                    }
                }
            }
            shotgunScript.sgReload = false;
        }
        ///////////////////////

        for (int i = 0; i < slotsNumber; i++)
        {
            if (slotStack[i] == 0)
            {
                ourInventory[i] = ItemData.itemList[0];
            }
        }



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ctrl = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            ctrl = false;
        }

        //dont show 0 in text
        for (int i = 0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == 0)
            {
                stackText[i].text = "";
            }
            else if (ourInventory[i].canUse == true)
            {
                stackText[i].text = "";
            }
            else
            {
                stackText[i].text = "" + slotStack[i];
            }
        }



        for (int i = 0; i < slotsNumber; i++)
        {
            slot[i].sprite = slotSprite[i];
        }
        for (int i = 0; i < slotsNumber; i++)
        {
            slotSprite[i] = ourInventory[i].itemSprite;

        }


        //take picked item data
        if (PickItem.y != null)
        {
            x = PickItem.y;
            n = x.GetComponent<ThisItem>().thisId;
        }
        else
        {
            x = null;
        }

        // add inv this item
        if (PickItem.pick == true)
        {
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == n)
                {
                    //check max stack for item
                    if (slotStack[i] == ourInventory[i].maxStack)
                    {
                        continue;
                    }
                    else
                    {
                        slotStack[i] += 1;
                        i = slotsNumber;
                        PickItem.pick = false;
                    }

                }
            }

            //
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && PickItem.pick == true)
                {
                    ourInventory[i] = ItemData.itemList[n];
                    slotStack[i] += 1;
                    PickItem.pick = false;



                    stackText[i].enabled = true;

                }
            }
            PickItem.pick = false;
        }


        if (ourInventory[b].consumable == true)
        {
            canConsume = true;
        }
        else
        {
            canConsume = false;
        }
        
        

        //CRAFT
        craftedItemName.text = "" + ItemData.itemList[craftableItemID].name;

        craftedItemSprite = ItemData.itemList[craftableItemID].itemSprite;
        craftedItem.sprite = craftedItemSprite;

        slotInCraftSprite[0] = ItemData.itemList[ItemData.itemList[craftableItemID].n1].itemSprite;
        slotInCraftSprite[1] = ItemData.itemList[ItemData.itemList[craftableItemID].n2].itemSprite;
        slotInCraftSprite[2] = ItemData.itemList[ItemData.itemList[craftableItemID].n3].itemSprite;

        slotInCraft[0].sprite = slotInCraftSprite[0];
        slotInCraft[1].sprite = slotInCraftSprite[1];
        slotInCraft[2].sprite = slotInCraftSprite[2];

        craftingText[0].text = "" + ItemData.itemList[craftableItemID].q1;
        craftingText[1].text = "" + ItemData.itemList[craftableItemID].q2;
        craftingText[2].text = "" + ItemData.itemList[craftableItemID].q3;


    }

    public void StartDrag(Image slotX)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            if (slot[i] == slotX)
            {
                a = i;
              
            }
        }
    }

    public void Drop(Image slotX)
    {
        if (shift == true && ctrl != true)
        {
            if (ourInventory[b].id == 0)
            {
                ourInventory[b] = ourInventory[a];
                slotStack[b] = slotStack[a] / 2;
                rest = slotStack[a] % 2;
                slotStack[a] = slotStack[a] / 2 + rest;
            }
        }
        else if (ctrl == true && shift != true)
        {
            if (ourInventory[b].id == 0)
            {
                ourInventory[b] = ourInventory[a];
                rest = slotStack[a] - 1;
                slotStack[b] = slotStack[a] - rest;
                slotStack[a] = rest;
            }
        }
        else
        {
            if (a != b)
            {
                if (ourInventory[a].id != ourInventory[b].id)
                {
                    if (a >= 20)
                    {

                        HotbarSlots[a - 20].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    }


                    draggedItem[0] = ourInventory[a];
                    slotTemporary = slotStack[a];
                    ourInventory[a] = ourInventory[b];
                    slotStack[a] = slotStack[b];
                    ourInventory[b] = draggedItem[0];
                    slotStack[b] = slotTemporary;
                    a = 0;
                    b = 0;


                }
                else
                {
                    if (slotStack[a] + slotStack[b] <= ourInventory[a].maxStack)
                    {
                        slotStack[b] = slotStack[a] + slotStack[b];
                        ourInventory[a] = ItemData.itemList[0];
                    }
                    else
                    {
                        slotStack[a] = slotStack[a] + slotStack[b] - ourInventory[a].maxStack;
                        slotStack[b] = ourInventory[a].maxStack;
                    }
                }


            }
        }
    }


    public void Enter(Image slotX)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            if (slot[i] == slotX)
            {
                b = i;
              
            }

        }
    }

    public void Hotbar()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                hotbarSizeHolder = i;
                if (ourInventory[20 + i].canUse == true && isOpen == false)
                {
                    Debug.Log("true");
                    isOpen = true;
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);


                    
                    holdSlotNumber = i;

                    if (ourInventory[20 + i].id == 16)
                    {
                        HotbarItems[0].SetActive(true);
                        axeOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(true);
                        bulletCount.SetActive(true);
                        revolverOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(true);
                        bulletCount.SetActive(true);
                        shotgunOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 19)
                    {
                        HotbarItems[3].SetActive(true);
                        torchOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 1)
                    {
                        HotbarItems[4].SetActive(true);
                        hammerOpen = true;
                    }
                }
                else if (ourInventory[20 + i].canUse == true && isOpen == true && i == holdSlotNumber)
                {
                    isOpen = false;
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);


                    if (ourInventory[20 + i].id == 16)
                    {
                        HotbarItems[0].SetActive(false);
                        axeOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(false);
                        bulletCount.SetActive(false);
                        revolverOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(false);
                        bulletCount.SetActive(false);
                        shotgunOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 19)
                    {
                        HotbarItems[3].SetActive(false);
                        torchOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 1)
                    {
                        HotbarItems[4].SetActive(false);
                        hammerOpen = false;
                    }
                }
                else if (ourInventory[20 + i].canUse == true && i != holdSlotNumber)
                {
                    HotbarSlots[holdSlotNumber].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);

                    isOpen = true;

                    if (ourInventory[20 + i].id == 16)
                    {
                        HotbarItems[0].SetActive(true);
                        HotbarItems[1].SetActive(false);
                        HotbarItems[2].SetActive(false);
                        HotbarItems[3].SetActive(false);
                        HotbarItems[4].SetActive(false);
                        bulletCount.SetActive(false);
                        torchOpen = false;
                        axeOpen = true;
                        revolverOpen = false;
                        shotgunOpen = false;
                        hammerOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(true);
                        HotbarItems[2].SetActive(false);
                        HotbarItems[0].SetActive(false);
                        HotbarItems[3].SetActive(false);
                        HotbarItems[4].SetActive(false);
                        bulletCount.SetActive(true);
                        torchOpen = false;
                        axeOpen = false;
                        revolverOpen = true;
                        shotgunOpen = false;
                        hammerOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(true);
                        HotbarItems[0].SetActive(false);
                        HotbarItems[1].SetActive(false);
                        HotbarItems[3].SetActive(false);
                        HotbarItems[4].SetActive(false);
                        bulletCount.SetActive(true);
                        torchOpen = false;
                        axeOpen = false;
                        revolverOpen = false;
                        shotgunOpen = true;
                        hammerOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 19)
                    {
                        HotbarItems[2].SetActive(false);
                        HotbarItems[0].SetActive(false);
                        HotbarItems[1].SetActive(false);
                        HotbarItems[3].SetActive(true);
                        HotbarItems[4].SetActive(false);
                        bulletCount.SetActive(false);
                        torchOpen = true;
                        axeOpen = false;
                        revolverOpen = false;
                        shotgunOpen = false;
                        hammerOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 1)
                    {
                        HotbarItems[2].SetActive(false);
                        HotbarItems[0].SetActive(false);
                        HotbarItems[1].SetActive(false);
                        HotbarItems[3].SetActive(false);
                        HotbarItems[4].SetActive(true);
                        bulletCount.SetActive(false);
                        torchOpen = false;
                        axeOpen = false;
                        revolverOpen = false;
                        shotgunOpen = false;
                        hammerOpen = true;
                    }

                    holdSlotNumber = i;

                }
                else if (ourInventory[20 + i].id != 16 && ourInventory[20 + i].id != 2 && ourInventory[20 + i].id != 3 && ourInventory[20 + i].id != 19 && ourInventory[20 + i].id != 1)
                {
                    HotbarSlots[0].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[1].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[2].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[3].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[4].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    HotbarSlots[5].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                    
                }


            }
            else
            {
                if (ourInventory[20 + hotbarSizeHolder].id == 16 && isOpen == true)
                {
                    HotbarItems[0].SetActive(true);
                    HotbarItems[1].SetActive(false);
                    HotbarItems[2].SetActive(false);
                    HotbarItems[3].SetActive(false);
                    HotbarItems[4].SetActive(false);
                    bulletCount.SetActive(false);
                    torchOpen = false;
                    axeOpen = true;
                    revolverOpen = false;
                    shotgunOpen = false;
                    hammerOpen = false;
                    HotbarSlots[hotbarSizeHolder].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                }
                else if (ourInventory[20 + hotbarSizeHolder].id == 2 && isOpen == true)
                {
                    HotbarItems[1].SetActive(true);
                    HotbarItems[2].SetActive(false);
                    HotbarItems[0].SetActive(false);
                    HotbarItems[3].SetActive(false);
                    HotbarItems[4].SetActive(false);
                    bulletCount.SetActive(true);
                    torchOpen = false;
                    axeOpen = false;
                    revolverOpen = true;
                    shotgunOpen = false;
                    hammerOpen = false;
                    HotbarSlots[hotbarSizeHolder].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                }
                else if (ourInventory[20 + hotbarSizeHolder].id == 3 && isOpen == true)
                {
                    HotbarItems[2].SetActive(true);
                    HotbarItems[0].SetActive(false);
                    HotbarItems[1].SetActive(false);
                    HotbarItems[3].SetActive(false);
                    HotbarItems[4].SetActive(false);
                    bulletCount.SetActive(true);
                    torchOpen = false;
                    axeOpen = false;
                    revolverOpen = false;
                    shotgunOpen = true;
                    hammerOpen = false;
                    HotbarSlots[hotbarSizeHolder].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                }
                else if (ourInventory[20 + hotbarSizeHolder].id == 19 && isOpen == true)
                {
                    HotbarItems[2].SetActive(false);
                    HotbarItems[0].SetActive(false);
                    HotbarItems[1].SetActive(false);
                    HotbarItems[3].SetActive(true);
                    HotbarItems[4].SetActive(false);
                    bulletCount.SetActive(false);
                    torchOpen = true;
                    axeOpen = false;
                    revolverOpen = false;
                    shotgunOpen = false;
                    hammerOpen = false;
                    HotbarSlots[hotbarSizeHolder].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                }
                else if (ourInventory[20 + hotbarSizeHolder].id == 1 && isOpen == true)
                {
                    HotbarItems[2].SetActive(false);
                    HotbarItems[0].SetActive(false);
                    HotbarItems[1].SetActive(false);
                    HotbarItems[3].SetActive(false);
                    HotbarItems[4].SetActive(true);
                    bulletCount.SetActive(false);
                    torchOpen = false;
                    axeOpen = false;
                    revolverOpen = false;
                    shotgunOpen = false;
                    hammerOpen = true;
                    HotbarSlots[hotbarSizeHolder].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                }
            }

        }

        if (ourInventory[20 + hotbarSizeHolder].id != 16 && ourInventory[20 + hotbarSizeHolder].id != 2 && ourInventory[20 + hotbarSizeHolder].id != 3 && ourInventory[20 + hotbarSizeHolder].id != 19 && ourInventory[20 + hotbarSizeHolder].id != 1)
        {
            HotbarItems[2].SetActive(false);
            HotbarItems[0].SetActive(false);
            HotbarItems[1].SetActive(false);
            HotbarItems[3].SetActive(false);
            HotbarItems[4].SetActive(false);
            bulletCount.SetActive(false);
            torchOpen = false;
            axeOpen = false;
            revolverOpen = false;
            shotgunOpen = false;
            hammerOpen = false;
            
        }

    }


    private void closeInventory()
    {
        //Open and Close Inv
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryOpen == false)
            {
                InventorySlots.SetActive(true);
                inventoryOpen = true;
                Camera.GetComponent<MouseLook>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                InventorySlots.SetActive(false);
                inventoryOpen = false;
                Camera.GetComponent<MouseLook>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }



    //CraftMenu Left-Right Button
    public void PreviousItem()
    {
        if (craftableItemID > firstCraftableItemID)
        {
            craftableItemID--;
        }
    }
    public void NextItem()
    {
        if (craftableItemID < lastCraftableItemID)
        {
            craftableItemID++;
        }
    }



    public void CraftItem()
    {
        int a = 0;
        int b = 0;
        int c = 0;

        for (int i = 0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == ItemData.itemList[craftableItemID].n1)
            {
                a += slotStack[i];
            }
        }

        for (int i = 0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == ItemData.itemList[craftableItemID].n2)
            {
                b += slotStack[i];
            }
        }

        for (int i = 0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == ItemData.itemList[craftableItemID].n3)
            {
                c += slotStack[i];
            }
        }

        if (a >= ItemData.itemList[craftableItemID].q1 && b >= ItemData.itemList[craftableItemID].q2 && c >= ItemData.itemList[craftableItemID].q3)
        {
            craft = true;
        }
        else
        {
            craft = false;
        }

        if (craft == true)
        {
            a = ItemData.itemList[craftableItemID].q1;
            b = ItemData.itemList[craftableItemID].q2;
            c = ItemData.itemList[craftableItemID].q3;

            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == craftableItemID)
                {
                    if (slotStack[i] == ourInventory[i].maxStack)
                    {
                        continue;
                    }
                    else
                    {
                        slotStack[i] += 1;
                        i = slotsNumber;
                    }

                    for (int j = 0; j < slotsNumber; j++)
                    {
                        if (ourInventory[j].id == ItemData.itemList[craftableItemID].n1 && a > 0)
                        {
                            if (slotStack[j] > a)
                            {
                                slotStack[j] -= a;
                                a = 0;
                            }
                            else
                            {
                                a -= slotStack[j];
                                slotStack[j] = 0;
                                ourInventory[j] = ItemData.itemList[0];
                            }
                        }
                    }

                    for (int k = 0; k < slotsNumber; k++)
                    {
                        if (ourInventory[k].id == ItemData.itemList[craftableItemID].n2 && b > 0)
                        {
                            if (slotStack[k] > b)
                            {
                                slotStack[k] -= b;
                                b = 0;
                            }
                            else
                            {
                                b -= slotStack[k];
                                slotStack[k] = 0;
                                ourInventory[k] = ItemData.itemList[0];
                            }
                        }
                    }

                    for (int l = 0; l < slotsNumber; l++)
                    {
                        if (ourInventory[l].id == ItemData.itemList[craftableItemID].n3 && c > 0)
                        {
                            if (slotStack[l] > c)
                            {
                                slotStack[l] -= c;
                                c = 0;
                            }
                            else
                            {
                                c -= slotStack[l];
                                slotStack[l] = 0;
                                ourInventory[l] = ItemData.itemList[0];
                            }
                        }
                    }

                    craft = false;

                }
            }


            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && craft == true)
                {
                    ourInventory[i] = ItemData.itemList[craftableItemID];

                    slotStack[i] += 1;

                    for (int j = 0; j < slotsNumber; j++)
                    {
                        if (ourInventory[j].id == ItemData.itemList[craftableItemID].n1 && a > 0)
                        {
                            if (slotStack[j] > a)
                            {
                                slotStack[j] -= a;
                                a = 0;
                            }
                            else
                            {
                                a -= slotStack[j];
                                slotStack[j] = 0;
                                ourInventory[j] = ItemData.itemList[0];
                            }
                        }
                    }

                    for (int k = 0; k < slotsNumber; k++)
                    {
                        if (ourInventory[k].id == ItemData.itemList[craftableItemID].n2 && b > 0)
                        {
                            if (slotStack[k] > b)
                            {
                                slotStack[k] -= b;
                                a = 0;
                            }
                            else
                            {
                                b -= slotStack[k];
                                slotStack[k] = 0;
                                ourInventory[k] = ItemData.itemList[0];
                            }
                        }
                    }

                    for (int l = 0; l < slotsNumber; l++)
                    {
                        if (ourInventory[l].id == ItemData.itemList[craftableItemID].n3 && c > 0)
                        {
                            if (slotStack[l] > c)
                            {
                                slotStack[l] -= c;
                                c = 0;
                            }
                            else
                            {
                                c -= slotStack[l];
                                slotStack[l] = 0;
                                ourInventory[l] = ItemData.itemList[0];
                            }
                        }
                    }

                    craft = false;

                }
            }
        }

    }


    public void rightClickMenu()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (armorNO == 1 && ourInventory[b].description == "Armor")
            {
                ContextMenuArmor.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 70f, mousePos.z);
                ContextMenuArmor.SetActive(true);
                ContextMenuEat.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuNormal.SetActive(false);
                ContextMenuUnequip.SetActive(false);
                ContextMenuDelete.SetActive(false);
            }
            else if (armorNO == 1 && ourInventory[b].description == "Delete")
            {
                ContextMenuDelete.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuEat.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuNormal.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuUnequip.SetActive(false);
                ContextMenuDelete.SetActive(true);
            }
            else if (armorNO == 1 && ourInventory[b].description == "Eat")
            {
                ContextMenuEat.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 70f, mousePos.z);
                ContextMenuEat.SetActive(true);
                ContextMenuDrink.SetActive(false);
                ContextMenuNormal.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuUnequip.SetActive(false);
                ContextMenuDelete.SetActive(false);
            }
            else if (armorNO == 1 && ourInventory[b].description == "Drink")
            {
                ContextMenuDrink.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 70f, mousePos.z);
                ContextMenuDrink.SetActive(true);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuNormal.SetActive(false);
                ContextMenuUnequip.SetActive(false);
                ContextMenuDelete.SetActive(false);
            }
            else if (armorNO == 1 && ourInventory[b].description == "Normal")
            {
                ContextMenuNormal.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuNormal.SetActive(true);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuUnequip.SetActive(false);
                ContextMenuDelete.SetActive(false);
            }
            else if(isHelmet == true)
            {
                ContextMenuUnequip.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuUnequip.SetActive(true);
                ContextMenuNormal.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuDelete.SetActive(false);
                armorCheck = true;
            }
            else if (isChest == true)
            {
                ContextMenuUnequip.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuUnequip.SetActive(true);
                ContextMenuNormal.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuDelete.SetActive(false);
                armorCheck = true;
            }
            else if (isPant == true)
            {
                ContextMenuUnequip.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuUnequip.SetActive(true);
                ContextMenuNormal.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuDelete.SetActive(false);
                armorCheck = true;
            }
            else if (isBoots == true)
            {
                ContextMenuUnequip.GetComponent<RectTransform>().position = new Vector3(mousePos.x + 50f, mousePos.y - 25f, mousePos.z);
                ContextMenuUnequip.SetActive(true);
                ContextMenuNormal.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuDelete.SetActive(false);
                armorCheck = true;
            }
            else
            {
                ContextMenuUnequip.SetActive(false);
                ContextMenuNormal.SetActive(false);
                ContextMenuDrink.SetActive(false);
                ContextMenuEat.SetActive(false);
                ContextMenuArmor.SetActive(false);
                ContextMenuDelete.SetActive(false);
                armorCheck = false;
            }


        }
    
    }

    public void deleteItem()
    {
        if(ourInventory[b].description == "Delete")
        {
            ourInventory[b] = ItemData.itemList[0];
            ContextMenuArmor.SetActive(false);
            ContextMenuDelete.SetActive(false);
        }
    }
    public void takeArmor()
    {
        if(ourInventory[b].armorType == "helmet")
        {
            if(ourInventory[b].name == "Bear Helmet")
            {
                HSript.maxHealth += 7f;             
            }
            else if(ourInventory[b].name == "Boar Helmet")
            {
                HSript.maxHealth += 5f;
            }
            else if (ourInventory[b].name == "Deer Helmet")
            {
                HSript.maxHealth += 2f;
            }
            else if (ourInventory[b].name == "Wolf Helmet")
            {
                HSript.maxHealth += 5f;
            }

            HelmetSlot.sprite = ourInventory[b].itemSprite;
            ourInventory[b] = ItemData.itemList[0];
            slotStack[b] = 0;

        }
        if (ourInventory[b].armorType == "chest")
        {
            if (ourInventory[b].name == "Bear Chest")
            {
                HSript.maxHealth += 18f;
                
            }
            else if (ourInventory[b].name == "Boar Chest")
            {
                HSript.maxHealth += 6f;
            }
            else if (ourInventory[b].name == "Deer Chest")
            {
                HSript.maxHealth += 3f;
            }
            else if (ourInventory[b].name == "Wolf Chest")
            {
                HSript.maxHealth += 6f;
            }

            ChestSlot.sprite = ourInventory[b].itemSprite;
            ourInventory[b] = ItemData.itemList[0];
            slotStack[b] = 0;
        }
        if (ourInventory[b].armorType == "pant")
        {
            if (ourInventory[b].name == "Bear Pant")
            {
                HSript.maxHealth += 18f;         
            }
            else if (ourInventory[b].name == "Boar Pant")
            {
                HSript.maxHealth += 6f;
            }
            else if (ourInventory[b].name == "Deer Pant")
            {
                HSript.maxHealth += 3f;
            }
            else if (ourInventory[b].name == "Wolf Pant")
            {
                HSript.maxHealth += 6f;
            }

            PantSlot.sprite = ourInventory[b].itemSprite;
            ourInventory[b] = ItemData.itemList[0];
            slotStack[b] = 0;
        }
        if (ourInventory[b].armorType == "boots")
        {
            if (ourInventory[b].name == "Bear Boots")
            {
                HSript.maxHealth += 7f;
            }
            else if (ourInventory[b].name == "Boar Boots")
            {
                HSript.maxHealth += 5f;
            }
            else if (ourInventory[b].name == "Deer Boots")
            {
                HSript.maxHealth += 2f;
            }
            else if (ourInventory[b].name == "Wolf Boots")
            {
                HSript.maxHealth += 5f;
            }

            BootsSlot.sprite = ourInventory[b].itemSprite;
            ourInventory[b] = ItemData.itemList[0];
            slotStack[b] = 0;
        }
        ContextMenuArmor.SetActive(false);
    }

    public void unEquip()
    {
        if(holdArmorNo == 1)
        {
            Debug.Log(HelmetSlot.sprite.name);
            for(int i=0; i<slotsNumber; i++)
            {
                if(ourInventory[i].id == 0 && armorCheck == true)
                {
                    if (HelmetSlot.sprite.name == "25")
                    {
                        HSript.maxHealth -= 7f;                     
                    }
                    else if (HelmetSlot.sprite.name == "29")
                    {
                        HSript.maxHealth -= 5f;
                    }
                    else if (HelmetSlot.sprite.name == "33")
                    {
                        HSript.maxHealth -= 2f;
                    }
                    else if (HelmetSlot.sprite.name == "37")
                    {
                        HSript.maxHealth -= 5f;
                    }

                    ourInventory[i] = ItemData.itemList[int.Parse(HelmetSlot.sprite.name)];
                    slotStack[i] = 1;
                    stackText[i].enabled = true;
                    armorCheck = false;
                    ContextMenuUnequip.SetActive(false);
                }
                else if(ourInventory[i].id != 0)
                {
                    continue;
                }
            }

            HelmetSlot.sprite = null;
        }
        if (holdArmorNo == 2)
        {
            Debug.Log(ChestSlot.sprite.name);
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && armorCheck == true)
                {
                    if (HelmetSlot.sprite.name == "26")
                    {
                        HSript.maxHealth -= 18f;
                        
                    }
                    else if (HelmetSlot.sprite.name == "30")
                    {
                        HSript.maxHealth += 6f;
                    }
                    else if (HelmetSlot.sprite.name == "34")
                    {
                        HSript.maxHealth += 3f;
                    }
                    else if (HelmetSlot.sprite.name == "38")
                    {
                        HSript.maxHealth += 6f;
                    }

                    ourInventory[i] = ItemData.itemList[int.Parse(ChestSlot.sprite.name)];
                    slotStack[i] = 1;
                    stackText[i].enabled = true;
                    armorCheck = false;
                    ContextMenuUnequip.SetActive(false);
                }
                else
                {
                    continue;
                }
            }

            ChestSlot.sprite = null;
        }
        if (holdArmorNo == 3)
        {
            Debug.Log(PantSlot.sprite.name);
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && armorCheck == true)
                {
                    if (HelmetSlot.sprite.name == "27")
                    {
                        HSript.maxHealth -= 18f;
                    }
                    else if (HelmetSlot.sprite.name == "31")
                    {
                        HSript.maxHealth += 6f;
                    }
                    else if (HelmetSlot.sprite.name == "35")
                    {
                        HSript.maxHealth += 3f;
                    }
                    else if (HelmetSlot.sprite.name == "39")
                    {
                        HSript.maxHealth += 6f;
                    }

                    ourInventory[i] = ItemData.itemList[int.Parse(PantSlot.sprite.name)];
                    slotStack[i] = 1;
                    stackText[i].enabled = true;
                    armorCheck = false;
                    ContextMenuUnequip.SetActive(false);

                }
                else
                {
                    continue;
                }
            }

            PantSlot.sprite = null;
        }
        if (holdArmorNo == 4)
        {
            Debug.Log(BootsSlot.sprite.name);
            for (int i = 0; i < slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && armorCheck == true)
                {
                    if (HelmetSlot.sprite.name == "28")
                    {
                        HSript.maxHealth -= 7f;
                    }
                    else if (HelmetSlot.sprite.name == "32")
                    {
                        HSript.maxHealth += 5f;
                    }
                    else if (HelmetSlot.sprite.name == "36")
                    {
                        HSript.maxHealth += 2f;
                    }
                    else if (HelmetSlot.sprite.name == "40")
                    {
                        HSript.maxHealth += 5f;
                    }

                    ourInventory[i] = ItemData.itemList[int.Parse(BootsSlot.sprite.name)];
                    slotStack[i] = 1;
                    stackText[i].enabled = true;
                    armorCheck = false;
                    ContextMenuUnequip.SetActive(false);
                }
                else
                {
                    continue;
                }
            }
            BootsSlot.sprite = null;
        }
    }

    public void Drop()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            
            Instantiate(Deneme, denemeCube.position, Quaternion.identity);
        }*/

        if(ourInventory[b].description == "Normal" || ourInventory[b].description == "Eat")
        {
            Instantiate(dropItems[ourInventory[b].id], DropPoint.position, Quaternion.identity);
            Debug.Log("dropitem");
            if (slotStack[b] > 1)
            {
                slotStack[b]--;
            }
            else
            {
                ourInventory[b] = ItemData.itemList[0];
            }
            ContextMenuNormal.SetActive(false);
            ContextMenuEat.SetActive(false);
        }


    }

    public void EatItem()
    {
        if (canConsume == true && HSript.playerHealth != 100)
        {
            if (slotStack[b] == 1)
            {
                HSript.Heal(ourInventory[b].nutritionalValue);
               
                ourInventory[b] = ItemData.itemList[0];
                slotStack[b] = 0;
            }
            else
            {
                slotStack[b]--;
                HSript.Heal(ourInventory[b].nutritionalValue);
               
            }
           
            ContextMenuEat.SetActive(false);
        }

        if (canConsume == true && StarvingSystem.starvingSystem.currentHunger != 100)
        {
            if (slotStack[b] == 1)
            {
                StarvingSystem.starvingSystem.increase(ourInventory[b].nutritionalValue);

                ourInventory[b] = ItemData.itemList[0];
                slotStack[b] = 0;
            }

            else
            {
                slotStack[b]--;
                StarvingSystem.starvingSystem.increase(ourInventory[b].nutritionalValue);

            }


        }

    }

    public void DrinkWater()
    {
        if(canConsume == true && thirstSystem.thirstSystemScript.currentThirst != 100)
        {
            if(slotStack[b] == 1)
            {
                thirstSystem.thirstSystemScript.increaseThirst(ourInventory[b].nutritionalValue);
                ourInventory[b] = ItemData.itemList[0];
                slotStack[b] = 0;
            }
            else
            {
                slotStack[b]--;
                thirstSystem.thirstSystemScript.increaseThirst(ourInventory[b].nutritionalValue);
            }
            ContextMenuDrink.SetActive(false);
        }
    }

    public void BuildItem()
    {
        if(hammerOpen == true && buildMenuOpen == false)
        {
            
            buildUI.SetActive(true);
            Instantiate(buildItemsPreview[BuildId]);
            buildMenuOpen = true;
        }
        else if(hammerOpen == false)
        {
            buildUI.SetActive(false);
            buildSlots[0].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
            buildSlots[1].GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            buildSlots[2].GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            buildSlots[3].GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            BuildId = 0;
            buildMenuOpen = false;
        }


        if (Input.GetKeyDown(KeyCode.E) && buildMenuOpen == true)
        {
            if(BuildId < 3)
            {
                BuildId++;
                buildSlots[BuildId].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                buildSlots[BuildId - 1].GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);          
                BuildingItem.BuildingI.BuildDeath();
                Instantiate(buildItemsPreview[BuildId]);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && buildMenuOpen == true)
        {
            if(BuildId > 0)
            {
                BuildId--;
                buildSlots[BuildId].GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1);
                buildSlots[BuildId + 1].GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
                BuildingItem.BuildingI.BuildDeath();
                Instantiate(buildItemsPreview[BuildId]);

            }
        }




    }












}
