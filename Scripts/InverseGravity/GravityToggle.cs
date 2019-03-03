using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [Tooltip("Switch between single and multiple toggle of gravity properties")]
    public bool AllowToggle = false;

    [Tooltip("States wether gravity is inversed initially and can be set to default or the other way around")]
    public bool GravityInverseInitial = false;

    public KeyCode ToggleKey = KeyCode.Space;

    private bool _gravityInverse;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        _gravityInverse = GravityInverseInitial;
    }

    void Update()
    {
        if (Input.GetKeyDown(ToggleKey))
            _gravityInverse = AllowToggle ? !_gravityInverse : !GravityInverseInitial;
    }

    void FixedUpdate()
    {
        if (_gravityInverse)
            rigidbody.AddForce(Vector3.up * Physics.gravity.magnitude);
        else
            rigidbody.AddForce(-Vector3.up * Physics.gravity.magnitude);
    }
}
