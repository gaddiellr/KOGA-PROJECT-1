using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 40f;
    public float sensitivity = 100f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private Vector3 moveDirection;

    void Update()
    {
        float rotX = 0f;
        float rotY = 0f;
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            rotX = -1f;
        else if (Input.GetKey(KeyCode.S))
            rotX = 1f;
        xRotation -= rotX * sensitivity * Time.deltaTime;
        if (xRotation > 180f)
            xRotation -= 360f;
        if (xRotation < -180f)
            xRotation += 360f;
        if (Input.GetKey(KeyCode.A))
            rotY = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotY = 1f;
        yRotation += rotY * sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.right * rotX * sensitivity * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * rotY * sensitivity * Time.deltaTime, Space.Self);
        print(xRotation);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Vector3 normal = hit.normal;
        moveDirection = Vector3.Reflect(moveDirection, normal);

        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
