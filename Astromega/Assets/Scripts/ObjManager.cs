using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager Instance;
    public ObjSpawner spawner;

    void Awake()
    {
        Instance = this;
    }
}