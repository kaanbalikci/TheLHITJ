using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolling : MonoBehaviour
{
    
    public Transform[] points;
    
    private Transform targetWayPoint;
    int current;
    //movement
    private float speed;
    public float runSpeed;
    public float walkSpeed;
    private float rotationSpeed = 2.0f;
    //animations
    private Animator anim;
    private float currentPatrolTime = 0;
    private float currentBreakTime = 0;
    public float patrolTime = 10f;
    public float breakTime = 2f;
    private int counter = 1;
    public float deadTime;

    private void Awake()
    {
        //animator set
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentPatrolTime = patrolTime;
   
        current = 0;
        var playerAgent = GetComponent<NavMeshAgent>();


    }


    void Update()
    {

        //Updating current waypoint for AI rotation
        targetWayPoint = points[current];

        AIPatrol();
        Rotation();
        AIbBehaviour();


    }


    public void AIPatrol()
    {
        if (transform.position != points[current].position)
        {
            //if AI position is not equal to waypoint,AI move towards to waypoint
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);

        }
        else
        {
            //if AI position is equal to waypoint,AI move towards to next wayPoint
            current = (current + 1) % points.Length;
            
          

        }


    }

    public void AIbBehaviour()
    {

        AIHealth health = GetComponent<AIHealth>();

        if(health.hit == false && currentPatrolTime > 0)
        {
           
            currentPatrolTime -= 1 * Time.deltaTime;
            speed = runSpeed;
            //animation.SetBool("chase", false);
            anim.SetFloat("patrolTimer", currentPatrolTime);
            if (currentPatrolTime <= 0)
                {
                speed = walkSpeed;
                currentBreakTime = breakTime;

                   }
             }

        if(health.hit == false && currentPatrolTime <= 0)
        {
            currentBreakTime -= 1 * Time.deltaTime;
            anim.SetFloat("breakTimer", currentBreakTime);
            
           

            if (currentBreakTime <= 0)
                {
                currentPatrolTime = patrolTime;
                  }
             }

        if (health.hit == true)
        {
            escape();
        }

        if(health.Dead == true)
        {
            speed = 0;
            anim.SetBool("isDead", true);
            Destroy(gameObject, deadTime);
        }

    

    }
    private void escape()
    {
      
        AIHealth health = GetComponent<AIHealth>();
      
        health.hit = false;
      
        if (counter == 1)
        {
            currentBreakTime = 0;
            anim.SetFloat("breakTimer", currentBreakTime);
            currentPatrolTime = patrolTime * 2;
            counter--;
        }
        counter = 1;
        Debug.Log(counter);
        speed = runSpeed;
        currentPatrolTime -= 1 * Time.deltaTime;
        anim.SetFloat("patrolTimer", currentPatrolTime);
        
        if (currentPatrolTime <= 0)
        {

           
            speed = walkSpeed;
            currentBreakTime = breakTime;

        }

    }



    public void Rotation()
    {

        float rotationStep = rotationSpeed * Time.deltaTime;
        
        
        Vector3 directionToTarget = targetWayPoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        transform.rotation = rotationToTarget;


    }
   



}
