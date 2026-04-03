using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public static SphereManager Instance;
    public SphereSpawner spawner;

    void Awake()
    {
        Instance = this;
    }
}