using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shotgunScript : MonoBehaviour
{

    public float damage = 50f;
    public float range = 30f;
    public float reloadTime = 60f;
    public int maxAmmo = 2;
    public int magazineSize = 16;
    public static bool shtogunFire;
    public static bool sgReload;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEfectAnimal;
    public GameObject impactEffectWorld;
    public TextMeshProUGUI ammoInfoText1;
    public GameObject player;


    [HideInInspector] public bool canShoot = true;
    [HideInInspector] public int currentAmmo;
    [HideInInspector] public int currentMagazineAmmo;


    private bool isReloading = false;
    private Animator shotgunAnim;



    void Start()
    {
        shotgunAnim = player.GetComponent<Animator>();

        currentAmmo = maxAmmo;
    }

    void Update()
    {
        magazineSize = Inventory.inv.sgBulletCount * 2;
        

        inputManager();
        shotgunReload();
        ammoInfoText1.text = this.currentAmmo + " / " + this.magazineSize;
    }

    public void inputManager()
    {


        //shoot Input
        if (Input.GetMouseButtonDown(0))
        {

            if (canShoot == true && currentAmmo > 0)
            {

                Shoot();
                canShoot = false;
               
                StartCoroutine(Reload());
            }


        }
    }
    public void Shoot()
    {


        if (canShoot == true)
        {
            
            shotgunAnim.SetTrigger("shotgunShooting");
            muzzleFlash.Play();
            currentAmmo = 0;
            Debug.Log(currentAmmo);
            //define raycast
            RaycastHit hit;
            //using raycast to hit objects
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {

                Debug.Log(hit.transform.name);

            }



            //if hit object tag is not equal to animal 

            if (hit.transform.tag != "animal")
            {
                GameObject impactObect = Instantiate(impactEffectWorld, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactObect, 2f);

            }




            //fetching AIHealth script
            AIHealth target = hit.transform.GetComponent<AIHealth>();

            //if AIHealth Script is exist hit the damage
            if (target != null)
            {

                target.TakeDamage(damage);
                GameObject impactGO = Instantiate(impactEfectAnimal, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }



    }
    public void shotgunReload()
    {
      
        if (isReloading)
        {
            return;
        }

  

        if (currentAmmo == 0 && magazineSize == 0)
        {
       
            canShoot = false;
            shotgunAnim.SetBool("shotgunReload", false);

            return;

        }
        
        if (currentAmmo == 0 && isReloading == false)
        {
           
            StartCoroutine(Reload());
          
            return;
            
        }
    }
    IEnumerator Reload()
    {


        {

            if (magazineSize > maxAmmo)
            {
                sgReload = true;
                isReloading = true;
                //magazineSize = magazineSize - maxAmmo;
                shotgunAnim.SetBool("shotgunReload", true);
                yield return new WaitForSeconds(2f);
                shotgunAnim.SetBool("shotgunReload", false);
                isReloading = false;
                currentAmmo = 2;
                canShoot = true;
            }
            else if (magazineSize == maxAmmo)
            {
                isReloading = true;
                magazineSize = 0;
                
                yield return new WaitForSeconds(2f);
              
                currentAmmo = maxAmmo;
                isReloading = false;
                canShoot = true;
            }
            
        }
    }
   IEnumerator shotgunShoot()
    {

        shotgunAnim.SetTrigger("shotgunShooting");
        yield return new WaitForSeconds(0.2f);

        canShoot = true;


    }
}



