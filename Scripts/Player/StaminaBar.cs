using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{


    public float maxStamina = 200;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;


    public Slider staminaBar;
    [HideInInspector] public float currentStamina;
    public static StaminaBar instance;
    public bool extraStamina;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;


    }

    
    void Update()
    {
        staminaBuff();
    }

   

    public void UseStamina(float amount)
    {
        //stamina changes
        if(currentStamina - amount >= 0)
        {


            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);
            
            }
            regen = StartCoroutine(RegenStamina());
        }
        else
        {

            Debug.Log("Not enough stamina to run");
        }



    }

    IEnumerator RegenStamina()
    {

        yield return new WaitForSeconds(2);
        

        while(currentStamina < maxStamina)
        {

            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }

        regen = null;

            
     }

   public void staminaBuff()
    {
        //sample for future
        if(extraStamina == true)
        {
            if(currentStamina < maxStamina)
            {
             currentStamina += 20f;
                staminaBar.value = currentStamina;
            }
           


            extraStamina = false;
        }


    }

}
