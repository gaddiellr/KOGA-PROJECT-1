/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, 0, -_joystick.Vertical * moveSpeed);
    }
}
*/
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;
    private Vector3 _moveDirection;

    void Update()
    {
        _moveDirection = new Vector3(_joystick.Horizontal, 0, -_joystick.Vertical);
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * moveSpeed;
    }
}