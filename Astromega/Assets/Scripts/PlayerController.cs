using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;
    public GameObject black;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Vertical * moveSpeed, -_joystick.Horizontal * moveSpeed, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackHole"))
        {
            black.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        black.SetActive(false);
    }
}