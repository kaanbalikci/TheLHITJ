using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestMenager : MonoBehaviour
{
    private int questId = 1;
    public TMP_Text questTitle;
    public TMP_Text first;
    private bool buttonTrigger;
    public GameObject uncleHouse;
    public GameObject finishPanel;
    private bool quest6;

    private void Update()
    {
        questTitle.text = "quest " + questId;
        first.text = QuestData.questList[questId].quest;

        if(questId == 1)
        {
            for(int i = 0; i < Inventory.inv.slotsNumber; i++)
            {
                if(Inventory.inv.ourInventory[i].id == 16)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if(questId == 2)
        {
            for (int i = 0; i < Inventory.inv.slotsNumber; i++)
            {
                if (Inventory.inv.ourInventory[i].id == 21)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if(questId == 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int idHolder = PickItem.y.GetComponent<ThisItem>().thisId;

                if(ItemData.itemList[idHolder].description == "Eat")
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if(questId == 4)
        {
            if(PlayerMovement.quest4 == true)
            {
                questId++;
                questTitle.text = "quest " + questId;
                first.text = QuestData.questList[questId].quest;
            }
        }
        else if (questId == 5)
        {
            for (int i = 0; i < Inventory.inv.slotsNumber; i++)
            {
                if (Inventory.inv.ourInventory[i].id == 22)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                    uncleHouse.SetActive(true);
                }
            }
        }
        else if (questId == 6)
        {
            if(PlayerMovement.quest6 == true)
            {
                questId++;
                questTitle.text = "quest " + questId;
                first.text = QuestData.questList[questId].quest;
            }
        }
        else if (questId == 7)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int idHolder2 = PickItem.y.GetComponent<ThisItem>().thisId;               

                if (ItemData.itemList[idHolder2].id == 2 || ItemData.itemList[idHolder2].id == 3)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if (questId == 8)
        {
            for (int i = 0; i < Inventory.inv.slotsNumber; i++)
            {
                if (Inventory.inv.ourInventory[i].id == 24)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if (questId == 9)
        {
            for (int i = 0; i < Inventory.inv.slotsNumber; i++)
            {
                if (Inventory.inv.ourInventory[i].id == 23)
                {
                    questId++;
                    questTitle.text = "quest " + questId;
                    first.text = QuestData.questList[questId].quest;
                }
            }
        }
        else if (questId == 10)
        {
            if(PlayerMovement.quest10 == true)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
                finishPanel.SetActive(true);
            }
        }

    }

 
}
