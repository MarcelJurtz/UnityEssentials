using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to toggle player location between given set of locations
/// </summary>
/// <remarks>
/// Update trigger in Update()-Method if required.
/// Default: 
///   - Keypad + switches to next position
///   - Keypad - switches to previous position
/// </remarks>
public class LocationToggle : MonoBehaviour
{
    public List<Transform> Locations;
    public GameObject Player;

    private int index = 0;
    private bool isFirstLoad = true;

    /// <summary>
    /// Sets location to the next one in the list. Location is set to initial position on first execution.
    /// </summary>
    public void ToggleForward()
    {
        if (!isFirstLoad)
            IncrementLocation();

        isFirstLoad = false;

        Player.transform.position = Locations[index].position;
    }

    /// <summary>
    /// Sets location to the previous one in the list. Location is set to initial position on first execution.
    /// </summary>
    public void ToggleBackwards()
    {
        if (!isFirstLoad)
            DecrementLocation();

        isFirstLoad = false;

        Player.transform.position = Locations[index].position;
    }

    private void IncrementLocation()
    {
        index++;
        if (index > Locations.Count - 1)
            index = 0;
    }

    private void DecrementLocation()
    {
        index--;
        if (index == -1)
            index = Locations.Count - 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            ToggleForward();
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
            ToggleBackwards();
    }
}
