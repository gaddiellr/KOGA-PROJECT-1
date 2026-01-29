using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputSetup : MonoBehaviour
{
    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDestroy()
    {
        EnhancedTouchSupport.Disable();
    }
}