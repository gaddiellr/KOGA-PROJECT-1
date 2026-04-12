//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private Rigidbody _rigidbody;
//    [SerializeField] private FixedJoystick _joystick;
//    [SerializeField] private float moveSpeed;

//    private void FixedUpdate()
//    {
//        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, 0, -_joystick.Vertical * moveSpeed);
//    }
//}
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private JoystickSelector joystickSelector; // Referencia al selector
    [SerializeField] private float moveSpeed = 5f;

    private void FixedUpdate()
    {
        // Obtener el joystick que actualmente debe estar activo
        FixedJoystick activeJoystick = joystickSelector != null ? joystickSelector.GetCurrentJoystick() : null;

        if (activeJoystick != null)
        {
            // Usar los valores del joystick activo
            float horizontal = activeJoystick.Horizontal;
            float vertical = activeJoystick.Vertical;

            _rigidbody.velocity = new Vector3(horizontal * moveSpeed, 0, -vertical * moveSpeed);
        }
        else
        {
            // Si no hay joystick activo, el personaje se detiene
            _rigidbody.velocity = Vector3.zero;
        }
    }
}