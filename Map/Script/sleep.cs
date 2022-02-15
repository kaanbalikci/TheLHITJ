using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    double TimeOfDay2Digits;

    float timerforpanels = 5f;

    int BedTriggerCounter;
    GameObject BlackScreen, Loading, dream, minimap, seedcode;

    bool timecontrol;

    RaycastHit Ray;
    void Start()
    {
        
    }
    private void Awake()
    {
        BlackScreen = GameObject.Find("Canvas/Panel");
        Loading = GameObject.Find("Canvas/Panel/Text (TMP)"); //"Monster/Arm/Hand"
        dream = GameObject.Find("Canvas/Panel/Dream");
        minimap = GameObject.Find("Canvas/Minimap");
        seedcode = GameObject.Find("Canvas/SeedCode");
    }

    void Update()
    {
        sleepControl();
    }

    void sleepControl()
    {
        TimeOfDay2Digits = System.Math.Round(LightingManager.TimeOfDay, 2);
        if (Input.GetKeyDown(KeyCode.E) && BedTriggerCounter == 1)
        {
            if (TimeOfDay2Digits >= 18 && TimeOfDay2Digits < 24)
            {
                LightingManager.TimeOfDay = 12f;
                LightingManager.day++;
                BlackScreen.SetActive(true);
                Loading.SetActive(false);
                dream.SetActive(true);
                minimap.SetActive(false);
                seedcode.SetActive(false);
                timecontrol = true;
              
            }
            else if (TimeOfDay2Digits >= 0 && TimeOfDay2Digits <= 5)
            {
                LightingManager.TimeOfDay = 12f;
                BlackScreen.SetActive(true);
                Loading.SetActive(false);
                dream.SetActive(true);
                minimap.SetActive(false);
                seedcode.SetActive(false);
                timecontrol = true;
            
            }
        }
        if (timecontrol)
        {
            timerforpanels -= Time.deltaTime;
            if (timerforpanels <= 0)
            {
                BlackScreen.SetActive(false);
                minimap.SetActive(true);
                seedcode.SetActive(true);
                timecontrol = false;
                timerforpanels = 5f;
               
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BedTriggerCounter = 1;
         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BedTriggerCounter = 0;
            
        }
    }
}
