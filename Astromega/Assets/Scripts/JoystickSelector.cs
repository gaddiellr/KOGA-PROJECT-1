using UnityEngine;

public class JoystickSelector:MonoBehaviour
{
   
    public FixedJoystick leftJoystick;   // Joystick del LeftCanvas
    public FixedJoystick rightJoystick;  // Joystick del RightCanvas


    public GameObject leftCanvas;        // El LeftCanvas (cuando está activo, se usa leftJoystick)
    public GameObject rightCanvas;       // El RightCanvas (cuando está activo, se usa rightJoystick)


    public bool disableInactiveJoystick = true; // Si true, desactiva el componente del joystick no usado

    private FixedJoystick currentActiveJoystick;

    void Update()
    {
        // Determinar qué canvas está activo
        bool leftActive = leftCanvas != null && leftCanvas.activeInHierarchy;
        bool rightActive = rightCanvas != null && rightCanvas.activeInHierarchy;

        if (leftActive && !rightActive)
        {
            // Usar joystick izquierdo
            SetActiveJoystick(leftJoystick, rightJoystick);
        }
        else if (rightActive && !leftActive)
        {
            // Usar joystick derecho
            SetActiveJoystick(rightJoystick, leftJoystick);
        }
        else
        {
            // Si ambos están activos o ninguno, decides qué hacer:
            // Por ejemplo, desactivar ambos o mantener el último.
            // Aquí desactivamos ambos para evitar conflictos.
            SetActiveJoystick(null, null);
        }
    }

    private void SetActiveJoystick(FixedJoystick toEnable, FixedJoystick toDisable)
    {
        if (disableInactiveJoystick)
        {
            // Habilitar el joystick que debe usarse
            if (toEnable != null && !toEnable.enabled)
                toEnable.enabled = true;

            // Deshabilitar el otro
            if (toDisable != null && toDisable.enabled)
                toDisable.enabled = false;
        }

        currentActiveJoystick = toEnable;
    }

    // Opcional: método público para obtener el joystick activo actualmente
    public FixedJoystick GetCurrentJoystick()
    {
        return currentActiveJoystick;
    }
}