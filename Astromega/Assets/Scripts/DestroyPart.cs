using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPart : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Destroy(other);
    }
}
