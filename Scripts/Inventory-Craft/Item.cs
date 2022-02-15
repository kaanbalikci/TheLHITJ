using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Item
{

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
    public string armorType;


    public Item()
    {

    }

    public Item(int Id,string Name, string Description, Sprite ItemSprite, int Stack, int MaxStack, bool CanUse, bool Consumable, int NutritionalValue, bool CanBeCraftable, int N1, int N2, int N3, int Q1, int Q2, int Q3, string ArmorType)
    {
        //ITEMS DATA
        id = Id;
        name = Name;
        description = Description;
        itemSprite = ItemSprite;
        stack = Stack;
        maxStack = MaxStack;
        canUse = CanUse;
        consumable = Consumable;
        nutritionalValue = NutritionalValue;
        canBeCraftable = CanBeCraftable;
        n1 = N1;
        n2 = N2;
        n3 = N3;
        q1 = Q1;
        q2 = Q2;
        q3 = Q3;
        armorType = ArmorType;

    }

}
