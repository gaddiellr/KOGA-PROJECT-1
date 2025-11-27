using UnityEngine;

public class EspCollision : MonoBehaviour
{
    [SerializeField] private int maxBounces = 5;
    [SerializeField] private float skinWidth = 0.015f;
    [SerializeField] private float maxSlopeAngle = 55f;
    [SerializeField] private LayerMask layerMask;

    private Collider col;
    private Bounds bounds;
    private bool isGrounded = false;

    void Awake()
    {
        col = GetComponent<Collider>();
    }

    private Vector3 ProjectAndScale(Vector3 vec, Vector3 normal)
    {
        float mag = vec.magnitude;
        vec = Vector3.ProjectOnPlane(vec, normal).normalized;
        vec *= mag;
        return vec;
    }

    private Vector3 CollideAndSlide(Vector3 vel, Vector3 pos, int depth, bool gravityPass, Vector3 velInit)
    {
        if (depth >= maxBounces)
        {
            return Vector3.zero;
        }

        float dist = vel.magnitude + skinWidth;

        RaycastHit hit;
        if (Physics.SphereCast(pos, bounds.extents.x, vel.normalized, out hit, dist, layerMask))
        {
            Vector3 snapToSurface = vel.normalized * (hit.distance - skinWidth);
            Vector3 leftover = vel - snapToSurface;
            float angle = Vector3.Angle(Vector3.up, hit.normal);

            if (snapToSurface.magnitude <= skinWidth)
            {
                snapToSurface = Vector3.zero;
            }

            // normal ground / slope
            if (angle <= maxSlopeAngle)
            {
                if (gravityPass)
                {
                    return snapToSurface;
                }
                leftover = ProjectAndScale(leftover, hit.normal);
            }
            // wall or steep slope
            else
            {
                float scale = 1 - Vector3.Dot(
                    new Vector3(hit.normal.x, 0, hit.normal.z).normalized,
                    -new Vector3(velInit.x, 0, velInit.z).normalized
                );

                if (isGrounded && !gravityPass)
                {
                    leftover = ProjectAndScale(
                        new Vector3(leftover.x, 0, leftover.z),
                        new Vector3(hit.normal.x, 0, hit.normal.z).normalized
                    );
                    leftover *= scale;
                }
                else
                {
                    leftover = ProjectAndScale(leftover, hit.normal) * scale;
                }
            }

            return snapToSurface + CollideAndSlide(leftover, pos + snapToSurface, depth + 1, gravityPass, velInit);
        }
        return vel;
    }

    void Update()
    {
        bounds = col.bounds;
        bounds.Expand(-2 * skinWidth);
    }
}
