using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScriptRework : MonoBehaviour
{
    private float range = 1.5f;
    private Animator playerAnim;
    private bool canChop = true;
    private float useStamina = 15f;

    public GameObject player;
    public Camera fpsCam;
    public float axeDamage = 1f;
    public float axeAnimalDamage = 30f;
    public ParticleSystem chopEffect;
    public ParticleSystem bloodEffect;

 
    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }

   
    void Update()
    {

        if (canChop == true && StaminaBar.instance.currentStamina >= 20f)
        {

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(chop());

            }

        }

    }

    public void chopping()
    {
        canChop = true;
        playerAnim.SetTrigger("chopping");
        
        
        StartCoroutine(consumeStamina());

        //define raycast
        RaycastHit hit;
        //using raycast to hit objects
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward);
            Debug.Log(hit.transform.name);

        }
        else
        {
            Debug.Log("none");
        }


        TreeScript treeHealthScript = hit.transform.GetComponent<TreeScript>();
        if (treeHealthScript != null)
        {

            treeHealthScript.TakeDamage(axeDamage);
            StartCoroutine(woodEffect());

        }
      

        //fetching AIhealth script
        AIHealth AIHealthScript = hit.transform.GetComponent<AIHealth>();
        if (AIHealthScript != null)
        {
            AIHealthScript.TakeDamage(axeAnimalDamage);
            StartCoroutine(animalEffect());
           
        }
      

        BarrelScript BarrelScripts = hit.transform.GetComponent<BarrelScript>();
        if (BarrelScripts != null)
        {
            BarrelScripts.TakeDamage1(axeDamage);

            
        }
        





    }

    IEnumerator chop()
    {
        canChop = false;
        yield return new WaitForSeconds(0.4f);
        chopping();

        //canChop = true;
    }

    IEnumerator woodEffect()
    {



        yield return new WaitForSeconds(0.5f);
        chopEffect.Play();


    }

    IEnumerator animalEffect()
    {

        yield return new WaitForSeconds(0.5f);
        bloodEffect.Play();

    }

    IEnumerator consumeStamina()
    {

        yield return new WaitForSeconds(0.4f);

        StaminaBar.instance.UseStamina(useStamina);



    }
}
