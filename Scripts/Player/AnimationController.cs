using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

   
    private Animator playerAnim;
    private PlayerMovement playerSpeed;
    private Gun gunScript;
    private shotgunScript shotgunScript;
    private bool IsAxeTaken;
    private bool chopping;
    private bool IsPistolTaken;
    private bool pistolShooting;
    private bool IsShotgunTaken;
   


    public GameObject player;
    public GameObject revolver;
    public GameObject axe;
    public GameObject shotgun;

    public GameObject shotgunScript1;
    public GameObject pistolScript;
    






    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();
        gunScript = pistolScript.GetComponent<Gun>();
        shotgunScript = shotgunScript1.GetComponent<shotgunScript>();

    }
    

    void Update()
    {
        UpdateAnimation();

    }


    public void UpdateAnimation()
    {
        
        playerAnim.SetFloat("Speed", playerSpeed.speed);





        //crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("Crouch", true);



        }
        else
        {
            playerAnim.SetBool("Crouch", false);

        }

        if((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D)) || ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))))))
        {

            playerAnim.SetBool("CrouchWalk", true);

        }
        else
        {
            playerAnim.SetBool("CrouchWalk", false);

        }

        //JumpAnim
        if (Input.GetKey(KeyCode.Space))
        {

            playerAnim.SetBool("Jump", true);



        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetBool("Jump", false);

        }

        //axeAnimation
        //if axe taken and
        if (Inventory.inv.axeOpen == true)
        {
            axe.SetActive(true);
            playerAnim.SetBool("axeTaken", true);
            playerAnim.SetBool("pistolTaken", false);         

        }
        else if(Inventory.inv.axeOpen == false)
        {

            playerAnim.SetBool("axeTaken", false);
            IsAxeTaken = false;
            axe.SetActive(false);
        }
        /*if (IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha2))
        
        {
            IsAxeTaken = false;
            axe.SetActive(false);
            playerAnim.SetBool("axeTaken", false);
            playerAnim.SetBool("pistolTaken", true);
            revolver.SetActive(true);
        }*/



        /*
        if (Input.GetMouseButtonDown(0) && Inventory.inv.axeOpen == true)
        {
       
          
            playerAnim.SetTrigger("chopping");
            chopping = true;
            
        }
        */
        //pistol animation
        
        //if pistol taken 
      if (Inventory.inv.revolverOpen == true)
          {
            revolver.SetActive(true);
            playerAnim.SetBool("axeTaken", false);
            playerAnim.SetBool("pistolTaken", true);
            IsPistolTaken = true;

        }
        else if (Inventory.inv.revolverOpen == false)
        {
            
            revolver.SetActive(false);
            gunScript.canShoot = true;
            playerAnim.SetBool("pistolReload", false);
            playerAnim.SetBool("pistolTaken", false);
            IsPistolTaken = false;
         
        }
        /*if (IsAxeTaken == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            IsPistolTaken = false;
            gunScript.canShoot = true;
            revolver.SetActive(false);
            playerAnim.SetBool("pistolReload", false);
            playerAnim.SetBool("pistolTaken", false);
            playerAnim.SetBool("axeTaken", true);
           
            axe.SetActive(true);
            
        }*/

        if (Input.GetMouseButtonDown(0) && Inventory.inv.revolverOpen == true)
        {


            playerAnim.SetTrigger("pistolShooting");
            

        }

        if (Inventory.inv.shotgunOpen == true)
        {
            shotgun.SetActive(true);
            playerAnim.SetBool("axeTaken", false);
            playerAnim.SetBool("pistolTaken", false);
            playerAnim.SetBool("shotgunTaken", true);
            IsShotgunTaken = true;

        }
        else if (Inventory.inv.shotgunOpen == false)
        {
            shotgun.SetActive(false);
            shotgunScript.canShoot = true;
            
            playerAnim.SetBool("shotgunTaken", false);
            playerAnim.SetBool("shotgunReload", false);
            IsShotgunTaken = true;

        }


    
    }

 
   
}
        

    





