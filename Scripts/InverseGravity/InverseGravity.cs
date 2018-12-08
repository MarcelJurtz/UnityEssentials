using UnityEngine;

/// <summary>
/// Invert gravity with optional rotation around a specified point
/// </summary>
public class InverseGravity : MonoBehaviour
{
    public float Gravity = 9.81f;
    public float OrbitDegreesPerSec = 120;
    public bool Orbit;
    public Rigidbody InvertedObject;
    public Transform CenterPoint;

    private Vector3 relativeDistance = Vector3.zero;

    void Start()
    {
        InvertedObject.useGravity = false;
        relativeDistance = transform.position - InvertedObject.gameObject.transform.position;
    }

    private void LateUpdate()
    {
        // Orbit
        if (Orbit && InvertedObject != null)
        {
            transform.position = CenterPoint.position + relativeDistance;
            transform.RotateAround(CenterPoint.position, Vector3.up, OrbitDegreesPerSec * Time.deltaTime);
            relativeDistance = transform.position - CenterPoint.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.up * Gravity;
        InvertedObject.AddForce(direction);
    }
}
