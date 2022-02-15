using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDay : MonoBehaviour
{

    public LayerMask oneday;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, oneday))
        {



        }
        
    }
}
