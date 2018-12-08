using UnityEngine;

/// <summary>
/// Script to toggle lights on and off
/// </summary>
public class LightSwitch : MonoBehaviour {

    public Light LightSource;

    [Tooltip("Button to switch light on and off")]
    public KeyCode Switch;

    private bool lightOn;

    private void Start()
    {
        lightOn = LightSource.enabled;
    }

    private void Update()
    {
        if (Input.GetKeyDown(Switch))
            ToggleLight();
    }

    void ToggleLight()
    {
        lightOn = !lightOn;
        LightSource.enabled = lightOn;
    }
}
