using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YedekPlay : MonoBehaviour
{
    CharacterController controller;

    //               *************PRIVATE**************

    //Vectors
    private Vector3 velocity;

    //bool
    private bool isGrounded;
    private bool isCrouching;
    private bool isRaycast;
    private bool cro;




    //float
    private float distance = 0.4f;
    private float jumpHeight = 2f;
    private float gravity = -30f;
    private float verticalVelocity;
    private float normalHeight = 2f;
    private float crouchHeight = 1f;
    private float crouchSpeed = 40f;

    //movement
    private float hori;
    private float vert;


    //speed
    public float speed = 3f;
    public float crouchsSpeed = 1f;
    public float runSpeed = 6f;
    public float idleSpeed = 0f;




    //                ********SERIALIZE FIELD*********
    [SerializeField] private Transform ground;
    [SerializeField] private LayerMask mask;






    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {

        //is player touch the ground
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);



        //Functions
        Movement();
        Jump();
        Gravity();
        Crouch();
        Run();
        Raycastci();

    }




    private void Movement()
    {
        //Player Movement Input
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        //Player Move
        Vector3 move = transform.right * hori + transform.forward * vert;
        controller.Move(move * speed * Time.deltaTime);


    }

    private void Jump()
    {
        //Jump Function
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }
        //jump force
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Gravity()
    {
        //Gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -7f;
        }


    }

    private void Crouch()
    {
        //CROUCH INPUT
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        if (isCrouching)
        {
            CharacterHeight(crouchHeight);
            if (controller.height - 0.05f <= crouchHeight)
            {
                controller.height = crouchHeight;


            }
        }
        else
        {
            if (controller.height < normalHeight && isRaycast == false)
            {

                float lastHeight = controller.height;

                CharacterHeight(normalHeight);

                if (controller.height + 0.05f >= normalHeight)
                {
                    controller.height = normalHeight;
                }
                transform.position += new Vector3(0, (controller.height - lastHeight) / 2, 0);

            }
        }


    }

    private void Raycastci()
    {
        //this function control is there any object above you
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, normalHeight))
        {
            isRaycast = true;
        }
        else
        {
            isRaycast = false;
        }
    }


    private void CharacterHeight(float newHeight)
    {
        //for smooth crouch
        controller.height = Mathf.Lerp(controller.height, newHeight, crouchSpeed * Time.deltaTime);
    }

    private void Run()
    {
        //run speed
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            speed = runSpeed;
        }
        //crouch speed
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            if (isGrounded)
            {
                speed = crouchsSpeed;
            }
        }
        else if (controller.height < 1.7f)
        {
            speed = crouchsSpeed;
        }
        else if (hori == 0 && vert == 0)
        {
            speed = idleSpeed;
        }
        //normal speed
        else
        {
            speed = 3f;
        }
    }
}
