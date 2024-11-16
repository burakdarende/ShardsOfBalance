using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller_Test : MonoBehaviour
{
    [SerializeField] float speed = 5f; 
    [SerializeField] float mouseSensitivity = 100f;

    Vector3 inputVector;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

     
        if (rb != null)
        {
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        RotatePlayer();
    }

    private void FixedUpdate()
    {

        Movement();
    }

    private void Movement()
    {

        Vector3 moveVector = transform.TransformDirection(inputVector.normalized) * speed;


        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime); 
    }

    private void RotatePlayer()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;


        transform.Rotate(Vector3.up * mouseX);
    }
}
