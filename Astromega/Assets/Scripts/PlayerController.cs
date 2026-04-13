using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;
    public GameObject black;
    private Vector4 imgColor;
    public Image img;
    public Material[] materials;
    private int x = 0;
    private bool enter = false;

    void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Vertical * moveSpeed, -_joystick.Horizontal * moveSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackHole"))
        {
            black.SetActive(true);
            imgColor = new Vector4(0f, 0f, 0f, 0.2f);
            enter = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BlackHole"))
        {
            if (imgColor.w < 1f)
            {
                imgColor.w += 0.2f;
                img.color = imgColor;
            }
            else
            {
                if (enter)
                {
                    List<int> select = new() {0, 1, 2, 3};
                    select.Remove(x);
                    x = select[Random.Range(0, select.Count)];
                    RenderSettings.skybox = materials[x];
                    enter = false;
                }
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        black.SetActive(false);
        img.color = new Vector4(0f, 0f, 0f, 0f);
    }
    
}