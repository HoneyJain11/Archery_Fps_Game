using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAim : MonoBehaviour
{
   private Rigidbody rb;
   [SerializeField] Camera setCamera;
   [SerializeField] float hoizontalSensitivity;
   [SerializeField] float verticalSensitivity;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        setCamera = GetComponentInChildren<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveBow();
    }
    // To do Bow Movement left-right and up-down with reference of a camera;
    void MoveBow()
    {
        float movementleftRight = Input.GetAxisRaw("Mouse X");
        float movementUpDown = Input.GetAxisRaw("Mouse Y");
        Vector3 bowRotateToX = new Vector3(movementUpDown * verticalSensitivity, 0, 0);
        Vector3 bowRotateToY = new Vector3(0, movementleftRight * hoizontalSensitivity, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(bowRotateToY));
        setCamera.transform.Rotate(-bowRotateToX);


    }
}
