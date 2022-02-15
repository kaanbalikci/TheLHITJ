using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{

    public enum biome { NONE, FIRST_BIOME, SECOND_BIOME, THIRD_BIOME };
    public enum Weather { NONE, SUNNY, RAIN, SNOW };
    public Weather currentWeather;
    public biome currentBiome;
    public ParticleSystem rain;
    public ParticleSystem snow;
    public ParticleSystem snow1;

    [Header("Light Settings")]
    public Light sunLight;
    public float defaultLightIntensity;
    private Color defaultLightColor;
    public Color rainColor;
    public Color winterColor;


    //time settings
    public static float timer;
    public float weatherTime = 10f;
    public float sunnyTime;
    public float rainTime;
    public float snowTime;
    //fog settings
    public float endDistance;

    private void Start()
    {
        Time.timeScale = 1f;
        LightingManager.LM.midnight = false;
        endDistance = 80f;
        currentBiome = biome.FIRST_BIOME;
        currentWeather = Weather.SUNNY;
        this.weatherTime = this.sunnyTime;
        this.defaultLightColor = this.sunLight.color;
        this.defaultLightIntensity = this.sunLight.intensity;

    }
    private void Update()
    {

        weatherController();

    }

    public void changeWeather(Weather weatherType)
    {
        if (weatherType != this.currentWeather)
        {
            //switching weather
            switch (weatherType)
            {
                case Weather.SUNNY:
                    currentWeather = Weather.SUNNY;
                    break;
                case Weather.RAIN:
                    currentWeather = Weather.RAIN;
                    rain.Play();
                    break;
                case Weather.SNOW:
                    currentWeather = Weather.SNOW;
                    snow.Play();
                    snow1.Play();
                    break;

            }

        }
    }


    public void weatherController()
    {

        //if current weather sunny start sunny timer 
        if (this.currentWeather == Weather.SUNNY)
        {

            this.sunnyTime -= Time.deltaTime / 60;
            aLerpLightColor(this.sunLight, defaultLightColor);

            //if midnights end or rain fog still exist on map,remove fog or darkness
            if (endDistance < 80f && LightingManager.LM.midnight == false)
            {

                for (float i = endDistance; i < 80f; i++)
                {

                    endDistance += Time.deltaTime / 30f;
                    RenderSettings.fogEndDistance = endDistance;

                }
                
            }

        }
        else
        {
            sunnyTime = weatherTime;
        }

        //Rain
        if (this.currentWeather == Weather.RAIN)
        {
          
            rainTime -= Time.deltaTime / 60f;
            aLerpLightColor(this.sunLight, rainColor);
            FreezingSystem.freezeSystem.decreaseDegree(0.0005f);
            //if its not midnight or its not first biome then creat fog
            if (endDistance >= 14f && currentBiome == biome.SECOND_BIOME && LightingManager.LM.midnight == false)
            {

                RenderSettings.fogColor = Color.grey;
                endDistance -= Time.deltaTime;
                RenderSettings.fogEndDistance = endDistance;
            }
           


        }
        else
        {
            rain.Stop();
            rainTime = weatherTime / 2f;
        }


        if (this.currentWeather == Weather.SNOW)
        {

            snowTime -= Time.deltaTime / 60f;
            aLerpLightColor(this.sunLight, winterColor);

            if (endDistance <= 80f && LightingManager.LM.midnight == true)
            {

                aLerpLightColor(this.sunLight, rainColor);
            }
        }
        else
        {
            snow.Stop();
            snow1.Stop();
            snowTime = weatherTime / 2f;

        }







        //When midnight comes start darkness fog
        if (LightingManager.LM.midnight == true)
        {
            if (endDistance >= 7f)
            {
                FreezingSystem.freezeSystem.decreaseDegree(0.0005f);
                RenderSettings.fogColor = Color.black;
                endDistance -= Time.deltaTime;
                RenderSettings.fogEndDistance = endDistance;
            }


        }

        //if player at the first two biome
        if (this.currentBiome == biome.FIRST_BIOME || this.currentBiome == biome.SECOND_BIOME)
        {

              //if sunny timer become a zero start raining
            if (this.sunnyTime <= 0f)
            {
                changeWeather(Weather.RAIN);


            }
            //if rain timer become a zero start raining
                if (this.rainTime <= 0f)
                {
                changeWeather(Weather.SUNNY);


                }

            //if current biome is FIRST or SECOND stop snow if exits.
                if (this.currentWeather == Weather.SNOW)
                {
                    changeWeather(Weather.SUNNY);


                }


            }
        if(this.currentBiome == biome.THIRD_BIOME)
        {
            //if sunny timer become a zero start snowing
            if (this.sunnyTime <= 0f)
            {
                changeWeather(Weather.SNOW);


            }
            //if current biome is FIRST or SECOND stop rain if its exits.
            if (this.currentWeather == Weather.RAIN)
            {
                changeWeather(Weather.SUNNY);
            }

            //if snow timer become a zero start sunny
            if (this.snowTime <= 0f)
            {
                changeWeather(Weather.SUNNY);

            }



        }

    }

    
    private void aLerpLightColor(Light light, Color c)
    {
        light.color = Color.Lerp(light.color, c, 0.2f * Time.deltaTime);
      

    }

}
