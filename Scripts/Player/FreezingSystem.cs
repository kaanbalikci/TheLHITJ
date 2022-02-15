using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezingSystem : MonoBehaviour
{
    public float maxDegree = 100f;
    public float currentDegree;
    public Image ringDegreeBar;
    public GameObject player;
    public Image freezeImage;
    

    private float freezeTimer = 5f;
    private float lerpSpeed;
    private float degreePercentage;
    private WeatherManager weatherManager;
    private HealthScript HSript;
    public static FreezingSystem freezeSystem;


    private void Awake()
    {
        freezeSystem = this;
    }
    private void Start()
    {
        HSript = player.GetComponent<HealthScript>();
        currentDegree = maxDegree;
        weatherManager = GetComponent<WeatherManager>();
       
    }
    private void Update()
    {


        
        if (currentDegree > maxDegree) currentDegree = maxDegree;

        lerpSpeed = 3f * Time.deltaTime;

        DegreeBarFiller();
        ColorChanger();
        damageToPlayer();
        freezeEffect();

    }



    void DegreeBarFiller()
    {

        ringDegreeBar.fillAmount = Mathf.Lerp(ringDegreeBar.fillAmount, (currentDegree / maxDegree), lerpSpeed);
       

    }
    void ColorChanger()
    {
        //changing color of health color
        Color healthColor = Color.Lerp(Color.blue, Color.yellow, (currentDegree / maxDegree));
        ringDegreeBar.color = healthColor;
    }

    public void freezeEffect()
    {

        degreePercentage = (maxDegree - currentDegree) / 100;
        freezeImage.color = new Color(60, 255, 255, degreePercentage);



    }


    public void decreaseDegree(float decreaseD)
    {
        if (currentDegree > 0)
        {

          currentDegree -= decreaseD;
        }
         
    }
    public void increase(float increaseDegree)
    {
        if (currentDegree < maxDegree)
            currentDegree += increaseDegree;
    }

    
    public void damageToPlayer()
    {

        if(currentDegree < 10f && currentDegree > 0)
        {
            
           if(freezeTimer >= 5f)
            {
                HSript.takeDamage(5f);
                freezeTimer -= 5f;
            }
            else
            {
                freezeTimer +=1f * Time.deltaTime;
            }


        }
        


    }



}
