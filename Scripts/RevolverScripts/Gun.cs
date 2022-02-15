using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 70f;
    public float reloadTime = 60f;
    public int maxAmmo = 6;
    public int magazineSize = 12;
    public static bool pistolFire;
    public static bool revoReload;




    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEfectAnimal;
    public GameObject impactEffectWorld;
    public GameObject player;
    public TextMeshProUGUI ammoInfoText;

    [HideInInspector]public bool canShoot = true;
    [HideInInspector]public int currentAmmo;
    [HideInInspector]public bool looting = false;
    [HideInInspector] public int currentMagazineAmmo;
    private bool manuelReload = false;
    private bool isReloading = false;
    private int bulletRemainder;
    private Animator pistolAnim;


    private void Start()
    {

        pistolAnim = player.GetComponent<Animator>();
        currentAmmo = 0;
       
    }

  

    void Update()
    {
       

        inputManager();
        pistolReload();
        ammoLooting();






        currentMagazineAmmo = Inventory.inv.revoBulletCount;

        /*if (currentMagazineAmmo <= 6)
        {
            currentAmmo = Inventory.inv.revoBulletCount;
            currentMagazineAmmo = 0;
            ammoInfoText.text = this.currentAmmo + " / 0";
        }
        else if (Inventory.inv.revoBulletCount > 6 && Inventory.inv.revoBulletCount <= 12)
        {
            currentAmmo = 6;
            currentMagazineAmmo = Inventory.inv.revoBulletCount % 6;
            //currentAmmo = Inventory.inv.revoBulletCount - currentMagazineAmmo;
        }
        else if(Inventory.inv.revoBulletCount > 12)
        {
            currentAmmo = 6;
            currentMagazineAmmo = Inventory.inv.revoBulletCount - (Inventory.inv.revoBulletCount % 6 + 6) ;
        }*/
        //ammoInfoText.text = this.currentAmmo + " / " + this.currentMagazineAmmo;
        ammoInfoText.text = Inventory.inv.revoAmmo + " / " + currentMagazineAmmo;
    }


    public void inputManager()
    {

       
        //shoot Input
        if (Input.GetMouseButtonDown(0))
        {
       

            if(canShoot == true && Inventory.inv.revoAmmo > 0)
            {
                
                Shoot();
                canShoot = false;
                StartCoroutine(timeBetweenShots());
            }
           
           

        }

        //Manuel reload Input
        if (Input.GetKeyDown(KeyCode.R))
        {
            revoReload = true;    

            /*manuelReload = true;

            if (manuelReload == true)
            {
                
                if (isReloading == false && currentAmmo > 0 && currentAmmo < maxAmmo && magazineSize > 0)
                {
                    
                    bulletRemainder = maxAmmo - currentAmmo;
                    
                    if(bulletRemainder < magazineSize)
                    {
                        currentAmmo = maxAmmo;
                        
                        magazineSize = magazineSize - bulletRemainder;

                    }
                    else
                    {
                        
                        
                        currentAmmo = magazineSize + currentAmmo;
                        magazineSize = 0;
                        

                    }
                    bulletRemainder = 0;
                    StartCoroutine(Reload());
                    return;

                }          
            } */
        }  
    }

    

public void Shoot()
    {

  
        
        if(Inventory.inv.inventoryOpen == false)
        {

            if (currentAmmo > 0)
        {

            pistolFire = true;
            muzzleFlash.Play();
            //define raycast
            RaycastHit hit;
            //using raycast to hit objects
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {

                Debug.Log(hit.transform.name);

            }
            
            //fetching AIHealth script
            AIHealth target = hit.transform.GetComponent<AIHealth>();

        //if AIHealth Script is exist hit the damage
        if(target != null)
        {

            target.TakeDamage(damage);
            GameObject impactGO = Instantiate(impactEfectAnimal, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
            //if AIHealth Script is not exist use sand particle effect
            if (target == null)

            {
                 GameObject impactObect = Instantiate(impactEffectWorld, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactObect, 2f);

             }

            }
        }


}



    public void pistolReload()
    {
        if (isReloading)
        {
            return;
        }


       
        if (currentAmmo == 0 && magazineSize == 0)
        {
            canShoot = false;
            pistolAnim.SetBool("pistolReload", false);
            return;

        }
        
       if(currentAmmo == 0 && isReloading == false)
        {
            StartCoroutine(Reload());
            return;

        }
     

    }

    //if player looting or crafting ammo after empty magazine :v
    private void ammoLooting()
    {
        if(looting == true)
        {

            canShoot = true;

        }

        looting = false;



    }


   IEnumerator Reload()
    {
        //if manuel reload is off,auto reload  is enable
       if(manuelReload == false)
        {
 
        if (magazineSize >= maxAmmo)
        {

            currentAmmo = maxAmmo;
            magazineSize = magazineSize - maxAmmo;
           
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;

        }

        }

        isReloading = true;
        pistolAnim.SetBool("pistolReload", true);
        yield return new WaitForSeconds(reloadTime);
        pistolAnim.SetBool("pistolReload", false);
         isReloading = false;
        manuelReload = false;
    }




    private IEnumerator timeBetweenShots()
    {

        //wait between shots
        
        pistolAnim.SetTrigger("pistolShooting");
        yield return new WaitForSeconds(0.4f);
       
        canShoot = true;
     

       }


    
}
