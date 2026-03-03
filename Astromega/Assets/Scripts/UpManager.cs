using UnityEngine;

public class UpManager : MonoBehaviour
{
    public static UpManager Instance;

    public Shoot shootB;

    void Awake()
    {
        Instance = this;
    }
}