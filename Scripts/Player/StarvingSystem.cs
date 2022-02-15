using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarvingSystem : MonoBehaviour
{
    public float maxHunger = 100f;
    public float currentHunger;
    public Image ringHungerBar;
    public GameObject player;
   

    public float hungerTimer = 15f;
    private float starveTimer = 5f;
    private float lerpSpeed;
    private float degreePercentage;
    private WeatherManager weatherManager;
    private HealthScript HSript;
    public static StarvingSystem starvingSystem;


    private void Awake()
    {
        starvingSystem = this;
    }
    private void Start()
    {
        HSript = player.GetComponent<HealthScript>();
        currentHunger = 50f;
     

    }
    private void Update()
    {



        //if (maxHunger > currentHunger) currentHunger = maxHunger;

        lerpSpeed = 3f * Time.deltaTime;

        StarveBarFiller();
        ColorChanger();
        damageToPlayer();
        decreaseHunger();

    }



    void StarveBarFiller()
    {

        ringHungerBar.fillAmount = Mathf.Lerp(ringHungerBar.fillAmount, (currentHunger / maxHunger), lerpSpeed);


    }
    void ColorChanger()
    {
        //changing color of health color
        Color healthColor = Color.Lerp(Color.black, Color.red, (currentHunger / maxHunger));
        ringHungerBar.color = healthColor;
    }

    


    public void decreaseHunger()
    {
        if (hungerTimer > 0)
        {
            currentHunger -= 0.00015f;
            hungerTimer -= 0.010f * Time.deltaTime;
          
        }
        else if(hungerTimer <= 0)
        {
            hungerTimer = 15f;
        }

    }
    public void increase(float increaseHunger)
    {
        if (currentHunger < maxHunger)
            currentHunger += increaseHunger;
    }


    public void damageToPlayer()
    {

        if (currentHunger < 10f && maxHunger > 0)
        {

            if (starveTimer >= 5f)
            {
                HSript.takeDamage(5f);
                starveTimer -= 5f;
            }
            else
            {
                starveTimer += 1f * Time.deltaTime;
            }


        }



    }


}
