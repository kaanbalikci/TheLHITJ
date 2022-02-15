using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public static List<Quest> questList = new List<Quest>();

    void Awake()
    {
        questList.Add(new Quest(0, "None"));
        questList.Add(new Quest(1, "Create an axe"));
        questList.Add(new Quest(2, "Build a campfire"));
        questList.Add(new Quest(3, "You are hungry!! Find something to eat"));
        questList.Add(new Quest(4, "You are thirsty!! Find water source to drink water"));
        questList.Add(new Quest(5, "Build a tent"));
        questList.Add(new Quest(6, "Find your uncle's house"));
        questList.Add(new Quest(7, "Take weapons"));
        questList.Add(new Quest(8, "Build a wooden house"));
        questList.Add(new Quest(9, "Build a bed to sleep"));
        questList.Add(new Quest(10, "Find the Treasure"));
    }
}
