using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspMovement : MonoBehaviour
{
    public CharacterController controller;

    void Update()
    {
        float rotX = 0f;
        float rotY = 0f;

        if (Input.GetKey(KeyCode.W))
            rotX = -40f;
        else if (Input.GetKey(KeyCode.S))
            rotX = 40f;

        if (Input.GetKey(KeyCode.A))
            rotY = -40f;
        else if (Input.GetKey(KeyCode.D))
            rotY = 40f;

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}