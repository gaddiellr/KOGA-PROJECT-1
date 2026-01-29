using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public RectTransform buttonRect;
    public Image targetImage;
    private Vector2 circleCenter;
    private int radius;
    private float dt = 0.0f;
    private float lastT = -1f;

    void Start()
    {
        radius = Mathf.RoundToInt(buttonRect.sizeDelta.x / 2f);
        circleCenter = new Vector2(Screen.width + buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);;
        Debug.Log(radius);
        Debug.Log($"Pos X: {circleCenter.x}, Pos Y: {circleCenter.y}");
    }
    void Update()
    {
        if (Touchscreen.current != null)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.wasPressedThisFrame)
                {
                    Vector2 pos = touch.position.ReadValue();
                    TryFire(pos);
                }
            }
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryFire(Mouse.current.position.ReadValue());
        }
        dt= Time.time - lastT;
        if (dt <= 0.08f) targetImage.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        else targetImage.color = new Color(1f, 1f, 1f, 1f);
    }

    void TryFire(Vector2 screenPosition)
    {
        //if (screenPosition.x > Screen.width / 2)
        if (Vector2.Distance(screenPosition, circleCenter) <= radius)
        {
            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            lastT = Time.time;
        }
    }
}