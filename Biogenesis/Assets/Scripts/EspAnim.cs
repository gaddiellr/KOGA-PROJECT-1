using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EspAnim : MonoBehaviour
{
    [Tooltip("Animator to control. If empty, will use the Animator on this GameObject.")]
    public Animator animator;

    [Tooltip("Speed when not pressing F")]
    public float normalSpeed = 0.25f;

    [Tooltip("Speed while holding F")]
    public float fastSpeed = 1f;

    void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
        animator.speed = normalSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (animator.speed != fastSpeed)
                animator.speed = fastSpeed;
        }
        else
        {
            if (animator.speed != normalSpeed)
                animator.speed = normalSpeed;
        }
    }
}