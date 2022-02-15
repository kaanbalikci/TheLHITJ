using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform spawnPosition;
    public Transform spawnPosition2;

    public GameObject deer;
    public GameObject rabbit;
    public GameObject bear;
    public GameObject wolf;
    public GameObject boar;

    
    public int maxNumberOfRabbit;
    public int maxNumberOfDeer;
    public int maxNumberOfBear;
    public int maxNumberOfWolf;
    public int maxNumberOfBoar;


   [HideInInspector]public int numberOfDeer = 0;
   [HideInInspector]public int numberOfRabbit = 0;
   [HideInInspector]public int numberOfBear = 0;
   [HideInInspector]public int numberOfWolf = 0;
   [HideInInspector]public int numberOfBoar = 0;


    private AIHealth AIScript;
    private float xPos;
    private float zPos;
    

    void Start()
    {
        //AIScript = deer.GetComponent<AIHealth>();
        AIStartSpawn();
    
    }

    
    void Update()
    {

        currentNumberOfAI();
       
    }

    
        public void AIStartSpawn()
    {

        //spawning AI until deer AI counter reach numerOfAI
        while (numberOfDeer < maxNumberOfDeer)
        {
           
            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 90f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 180f);
            //Instantiate AI
            Instantiate(deer, new Vector3(xPos, spawnPosition.transform.position.y, zPos) , Quaternion.identity);
           
            numberOfDeer += 1;


        }
        
        //spawning AI until rabbit AI counter reach numerOfAI
        while (numberOfRabbit < maxNumberOfRabbit)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 90f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 180f);
            //Instantiate AI
            Instantiate(rabbit, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            
            numberOfRabbit += 1;
         }


        //Bear spawning at start
        while(numberOfBear < maxNumberOfBear)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 15f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(bear, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
            
            numberOfBear += 1;

            }

        //wolf spawning at start
        while (numberOfWolf < maxNumberOfWolf)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 15f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(wolf, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
           
            numberOfWolf += 1;

            }

        while (numberOfBoar < maxNumberOfBoar)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 15f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 30f);
            //Instantiate AI
            Instantiate(boar, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
            
            numberOfBoar += 1;

        }


    }
    public void currentNumberOfAI()
    {


        //if AI killed by player after game start spawn new one
        //deer
        if (numberOfDeer != maxNumberOfDeer)
        {

            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 30f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 60f);
            //Instantiate AI
            Instantiate(deer, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            numberOfDeer += 1;


        }
        //if AI killed by player spawn new one
        //rabbit spawn
        if (numberOfRabbit != maxNumberOfRabbit)
        {

            xPos = Random.Range(spawnPosition.transform.position.x, spawnPosition.transform.position.x + 30f);
            zPos = Random.Range(spawnPosition.transform.position.z, spawnPosition.transform.position.z + 60f);
            //Instantiate AI
            Instantiate(rabbit, new Vector3(xPos, spawnPosition.transform.position.y, zPos), Quaternion.identity);
            numberOfRabbit += 1;
             }
        
        //if AI killed by player after game start spawn new one
        //bear spawn
        if(numberOfBear != maxNumberOfBear)
        {
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 30f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 60f);
            //Instantiate AI
            Instantiate(bear, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
            numberOfBear += 1;
            }
        
        
        //if AI killed by player after game start spawn new one
        //wolf spawn
        if (numberOfWolf != maxNumberOfWolf)
        {
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 30f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 60f);
            //Instantiate AI
            Instantiate(wolf, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
            numberOfWolf += 1;
            }

        //boar spawn
        if (numberOfBoar != maxNumberOfBoar)
        {

            //giving random x and z axis between spawn point
            xPos = Random.Range(spawnPosition2.transform.position.x, spawnPosition.transform.position.x + 30f);
            zPos = Random.Range(spawnPosition2.transform.position.z, spawnPosition.transform.position.z + 60f);
            //Instantiate AI
            Instantiate(boar, new Vector3(xPos, spawnPosition2.transform.position.y, zPos), Quaternion.identity);
            
            numberOfBoar += 1;

        }

    }

}




