using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yedekMouse : MonoBehaviour
{

    [Range(100, 600)]
    [SerializeField] private float Sens = 300;

    [SerializeField] private Transform Body;

    private float xRot = 0f;

    private void Start()
    {
        //lock mouse on the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //input mouse axis
        float rotX = Input.GetAxisRaw("Mouse X") * Sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * Sens * Time.deltaTime;

        //clamp Y rotation 
        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -90f, 70f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);



        Body.Rotate(Vector3.up * rotX);
    }

}
