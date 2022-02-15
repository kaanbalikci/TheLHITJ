using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static List<Item> itemList = new List<Item>();

    void Awake()
    {
        // OUR DATABASE
        itemList.Add(new Item(0, "None", "None", Resources.Load <Sprite>("0"), 0 , 0 , false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(1, "Hammer", "Non", Resources.Load<Sprite>("1"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(2, "Revolver", "Normal", Resources.Load<Sprite>("2"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(3, "Shotgun", "Normal", Resources.Load<Sprite>("3"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(4, "Meat", "Eat", Resources.Load<Sprite>("4"), 0, 10, false, true, 20, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(5, "Banana", "Eat", Resources.Load<Sprite>("5"), 0, 20, false, true, 10, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(6, "Toxic Mushroom", "Eat", Resources.Load<Sprite>("6"), 0, -10, false, true, 10, false, 0, 0, 0, 0, 0, 0, "None")); 
        itemList.Add(new Item(7, "Wood", "Normal", Resources.Load<Sprite>("7"), 0, 25, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(8, "Rock", "Normal", Resources.Load<Sprite>("8"), 0, 50, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(9, "Metal", "Normal", Resources.Load<Sprite>("9"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));    //delete    
        itemList.Add(new Item(10, "Bear Pelt", "Normal", Resources.Load<Sprite>("10"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(11, "Boar Fur", "Normal", Resources.Load<Sprite>("11"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(12, "Deer Pelt", "Normal", Resources.Load<Sprite>("12"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(13, "Wolf Pelt", "Normal", Resources.Load<Sprite>("13"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(14, "Mushroom", "Eat", Resources.Load<Sprite>("14"), 0, 10, false, true, 10, false, 0, 0, 0, 0, 0, 0, "None"));
        itemList.Add(new Item(15, "Gunpowder", "Delete", Resources.Load<Sprite>("15"), 0, 50, false, false, 0, true, 0, 0, 0, 0, 0, 0, "None")); //delete
        // CRAFT ITEM

        itemList.Add(new Item(16, "Axe", "Normal", Resources.Load<Sprite>("16"), 0, 1, true, false, 0, true, 7, 8, 0, 5, 1, 0, "None"));
        itemList.Add(new Item(17, "Rope", "Delete", Resources.Load<Sprite>("17"), 0, 10, false, false, 0, true, 7, 12, 0, 1, 1, 0, "None")); //delete
        itemList.Add(new Item(18, "Revolver Bullet", "Delete", Resources.Load<Sprite>("18"), 0, 20, false, false, 0, true, 15, 9, 0, 1, 1, 0, "None"));
        itemList.Add(new Item(19, "Torch", "Normal", Resources.Load<Sprite>("19"), 0, 1, true, false, 0, true, 41, 8, 0, 2, 2, 0, "None"));
        itemList.Add(new Item(20, "Shotgun Bullet", "Delete", Resources.Load<Sprite>("20"), 0, 20, false, false, 0, true, 15, 9, 0, 1, 1, 0, "None"));
        //if change build item id you must change buildingItem script
        itemList.Add(new Item(21, "Campfire", "Craft", Resources.Load<Sprite>("21"), 0, 1, false, false, 0, true, 8, 7, 0, 3, 2, 0, "None"));
        itemList.Add(new Item(22, "Tent", "Craft", Resources.Load<Sprite>("22"), 0, 1, false, false, 0, true, 41, 17, 0, 5, 5, 0, "None"));
        itemList.Add(new Item(23, "Bed", "Craft", Resources.Load<Sprite>("23"), 0, 1, false, false, 0, true, 8, 0, 0, 5, 0, 0, "None"));
        itemList.Add(new Item(24, "WoodenHouse", "Craft", Resources.Load<Sprite>("24"), 0, 1, false, false, 0, true, 8, 7, 0, 10, 5, 0, "None"));


        //bear                                                                //change unequip script if change armors id     delete
        itemList.Add(new Item(25, "Bear Helmet", "Armor", Resources.Load<Sprite>("25"), 0, 1, false, false, 7, true, 10, 41, 0, 1, 1, 0, "helmet"));
        itemList.Add(new Item(26, "Bear Chest", "Armor", Resources.Load<Sprite>("26"), 0, 1, false, false, 18, true, 10, 41, 0, 1, 1, 0, "chest"));
        itemList.Add(new Item(27, "Bear Pant", "Armor", Resources.Load<Sprite>("27"), 0, 1, false, false, 18, true, 10, 41, 0, 1, 1, 0, "pant"));
        itemList.Add(new Item(28, "Bear Boots", "Armor", Resources.Load<Sprite>("28"), 0, 1, false, false, 7, true, 10, 41, 0, 1, 1, 0, "boots"));
        //boar
        itemList.Add(new Item(29, "Boar Helmet", "Armor", Resources.Load<Sprite>("29"), 0, 1, false, false, 5, true, 11, 41, 0, 1, 1, 0, "helmet"));
        itemList.Add(new Item(30, "Boar Chest", "Armor", Resources.Load<Sprite>("30"), 0, 1, false, false, 6, true, 11, 41, 0, 1, 1, 0, "chest"));
        itemList.Add(new Item(31, "Boar Pant", "Armor", Resources.Load<Sprite>("31"), 0, 1, false, false, 6, true, 11, 41, 0, 1, 1, 0, "pant"));
        itemList.Add(new Item(32, "Boar Boots", "Armor", Resources.Load<Sprite>("32"), 0, 1, false, false, 5, true, 11, 41, 0, 1, 1, 0, "boots"));
        //deer
        itemList.Add(new Item(33, "Deer Helmet", "Armor", Resources.Load<Sprite>("33"), 0, 1, false, false, 2, true, 12, 41, 0, 1, 1, 0, "helmet"));
        itemList.Add(new Item(34, "Deer Chest", "Armor", Resources.Load<Sprite>("34"), 0, 1, false, false, 3, true, 12, 41, 0, 1, 1, 0, "chest"));
        itemList.Add(new Item(35, "Deer Pant", "Armor", Resources.Load<Sprite>("35"), 0, 1, false, false, 3, true, 12, 41, 0, 1, 1, 0, "pant"));
        itemList.Add(new Item(36, "Deer Boots", "Armor", Resources.Load<Sprite>("36"), 0, 1, false, false, 2, true, 12, 41, 0, 1, 1, 0, "boots"));
        //wolf
        itemList.Add(new Item(37, "Wolf Helmet", "Armor", Resources.Load<Sprite>("37"), 0, 1, false, false, 5, true, 13, 41, 0, 1, 1, 0, "helmet"));
        itemList.Add(new Item(38, "Wolf Chest", "Armor", Resources.Load<Sprite>("38"), 0, 1, false, false, 6, true, 13, 41, 0, 1, 1, 0, "chest"));
        itemList.Add(new Item(39, "Wolf Pant", "Armor", Resources.Load<Sprite>("39"), 0, 1, false, false, 6, true, 13, 41, 0, 1, 1, 0, "pant"));
        itemList.Add(new Item(40, "Wolf Boots", "Armor", Resources.Load<Sprite>("40"), 0, 1, false, false, 5, true, 13, 41, 0, 1, 1, 0, "boots"));

        itemList.Add(new Item(41, "Stick", "Delete", Resources.Load<Sprite>("41"), 0, 50, false, false, 0, true, 7, 0, 0, 1, 0, 0, "None"));
    }
}
/*
    public int id;
    public string name;
    public string description;
    public Sprite itemSprite;
    public int stack;
    public int maxStack;
    public bool canUse;
    public bool consumable;
    public int nutritionalValue;
    public bool canBeCraftable;
    public int n1;
    public int n2;
    public int n3;
    public int q1;
    public int q2;
    public int q3;
    armorType = ArmorType;
*/