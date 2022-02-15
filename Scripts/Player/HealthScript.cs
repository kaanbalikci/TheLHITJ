using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour
{
   
    
   [HideInInspector] public float playerHealth;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool damageTaken;
    public Image bloodImage;
    public PlayerMovement movementScript;
    public float healthPercent;
    public GameObject GOScreen;
    public Transform[] Animal;
   
    
    public bool bearInsightRange, boarInsightRange, wolfInsightRange;

    //position record
    private float animal_x;
    private float animal_z;
    public float sightRange;
    private float player_x;
    private float player_z;
   
    
    private bool Healing;
 
   

    void Start()
    {
        
        playerHealth = maxHealth;
        currentHealth = playerHealth;
        movementScript = FindObjectOfType<PlayerMovement>();

    }

    
    void Update()
    {
       
        takeDamageKnock();
        knockBackController();
        UpdateBloodImage();
        


    }
   
   
    public void takeDamage(float amount)
    {
       
        if (playerHealth > 0) {

            currentHealth = playerHealth;
            playerHealth -= amount;
            


        }
        else if(playerHealth <= 0)
        {
            Time.timeScale = 0f;
          GOScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
    
        }
        
      

    }

    public void knockBackController()
    {


        if(currentHealth > playerHealth)
        {

            damageTaken = true;
        }

        
    }


    public void knockBack(Vector3 direction)
    {

        movementScript.KnockBack(direction);


    }

    public void takeDamageKnock()
    {

        if (damageTaken == true)
        {
            //is damage taken by survival conditions or by animal
            if(bearInsightRange == false && wolfInsightRange == false && boarInsightRange == false)
            {

                Debug.Log("damage by any condition");

            }
            else
            {
                StartCoroutine(knockBack());
            }
            
       
          
            

        }

         
    }
    public void UpdateBloodImage()
    {

      if(damageTaken == true)
        {
            healthPercent = (maxHealth - playerHealth) / 100;
            bloodImage.color = new Color(255, 0, 0, healthPercent);
        }
          
            
        }

    public void Heal(float amount)
    {


        if (playerHealth < maxHealth)
        {

            currentHealth = playerHealth;
            playerHealth += amount;

            healthPercent = (maxHealth - playerHealth) / 100;
            bloodImage.color = new Color(255, 0, 0, healthPercent);

        }
        else
        {

            Debug.Log("player is dead");
        }



        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "Bear(Clone)")
        {

            bearInsightRange = true;

        }
        else if(other.gameObject.name == "Boar(Clone)")
        {

            boarInsightRange = true;

        }
        else if(other.gameObject.name == "Wolf(Clone)")
        {

            wolfInsightRange = true;
        }
        
    
    
    }


    IEnumerator knockBack()
    {
        yield return new WaitForSeconds(0.8f);
       

        if (bearInsightRange == true)
        {
         
            Vector3 animalPosition = new Vector3(Animal[0].transform.position.x, Animal[0].transform.position.y, Animal[0].transform.position.z);
            animal_x = animalPosition.x;
            animal_z = animalPosition.z;
            bearInsightRange = false;

        }
        else if (boarInsightRange == true)
        {
          
            Vector3 animalPosition = new Vector3(Animal[1].transform.position.x, Animal[1].transform.position.y, Animal[1].transform.position.z);
            animal_x = animalPosition.x;
            animal_z = animalPosition.z;
            boarInsightRange = false;
        }
        else if (wolfInsightRange == true)
        {
            
            Vector3 animalPosition = new Vector3(Animal[2].transform.position.x, Animal[2].transform.position.y, Animal[2].transform.position.z);
            animal_x = animalPosition.x;
            animal_z = animalPosition.z;
            wolfInsightRange = false;
        }
        

       
        player_x = transform.position.x;
        player_z = transform.position.z;
        


         if(animal_x > 0)

            {

              if (animal_x > player_x)
                    {

                player_x -= 0.1f;
            

                    }
                 else
                 {

                  player_x += 0.1f;

                   }
                     }
            else
               {
            if (animal_x > player_x)
            {

                player_x += 0.1f;


            }
            else
            {

                player_x -= 0.1f;

            }

        }
            if (animal_z > 0)
                {


        
                if (animal_z > player_z)
                {

                player_z -= 0.2f;

                 }
                else
                    {

                player_z += 0.2f;
                       }
                }
        else
        {
            if (animal_z > player_z)
            {

                player_z -= 0.2f;

            }
            else
            {

                player_z += 0.2f;
            }

        }

   
        Vector3 playerTransform1 = new Vector3(player_x, transform.position.y, player_z);
        Vector3 hitDirection = transform.position = new Vector3(playerTransform1.x, playerTransform1.y, playerTransform1.z);
        




        hitDirection = hitDirection.normalized;
        
        knockBack(hitDirection);
        damageTaken = false;
        currentHealth = playerHealth;
        }
    

}

