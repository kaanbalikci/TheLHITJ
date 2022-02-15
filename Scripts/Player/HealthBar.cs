using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public Image ringHealthBar;
    public GameObject player;

    private float lerpSpeed;
    private HealthScript HSript;

    private void Start()
    {
        //using variables from player health script
        HSript = player.GetComponent<HealthScript>();
        HSript.playerHealth = HSript.maxHealth;
    }

    private void Update()
    {

        healthText.text = "" + HSript.playerHealth + "/" + HSript.maxHealth;
        if (HSript.playerHealth > HSript.maxHealth) HSript.playerHealth = HSript.maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
       
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (HSript.playerHealth / HSript.maxHealth), lerpSpeed);

       
    }
    void ColorChanger()
    {
        //changing color of health color
        Color healthColor = Color.Lerp(Color.red, Color.green, (HSript.playerHealth / HSript.maxHealth));
        ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (HSript.playerHealth > 0)
            HSript.playerHealth -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (HSript.playerHealth < HSript.maxHealth)
            HSript.playerHealth += healingPoints;
    }
    
    }

