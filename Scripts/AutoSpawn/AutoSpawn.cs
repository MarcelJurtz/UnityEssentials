using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to automatically spawn a specific GameObject
/// </summary>
/// <remarks>
/// Specify LoopSpawn to repeat spawning by specified interval
/// </remarks>
public class Spawner : MonoBehaviour {

    public GameObject SpawnableObject;
    public List<Transform> SpawnLocations;
    public ObjectSpawnMode SpawnMode = ObjectSpawnMode.Single;

    public float Delay;
    public bool LoopSpawn;
    public float SpawnInterval;

    private Transform _spawnLocation;
    private System.Random random;
    private int index = 0;

    /// <summary>
    /// Initiates script and executes spawn after specified delay
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when no spawn locations are specified</exception>"
    /// <exception cref="ArgumentException">Thrown when looped spawning is activated but the spawn interval is set to zero</exception>
    void Start()
    {
        if (SpawnLocations.Count == 0)
            throw new ArgumentException("Specify at least one spawn location.");

        random = new System.Random();

        if (LoopSpawn)
        {
            if (SpawnInterval > 0)
                InvokeRepeating(nameof(Spawn), Delay, SpawnInterval);
            else
                throw new ArgumentException("To use looped spawning, specify a spawn interval greater than 0");
        }
        else
        {
            Invoke(nameof(Spawn), Delay);
        }
    }

    /// <summary>
    /// Spawns the specified object in the given mode
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an invalid enum value is passed</exception>
    private void Spawn()
    {
        if (SpawnLocations.Count == 1)
            _spawnLocation = SpawnLocations[0];
        else
        {
            switch(SpawnMode)
            {
                case ObjectSpawnMode.Single:
                    _spawnLocation = SpawnLocations[0];
                    break;
                case ObjectSpawnMode.Chronologically:
                    _spawnLocation = SpawnLocations[index];
                    index = index == SpawnLocations.Count - 1 ? 0 : index +1;
                    break;
                case ObjectSpawnMode.Random:
                    index = random.Next(0, SpawnLocations.Count - 1);
                    _spawnLocation = SpawnLocations[index];
                    break;
                default:
                    throw new InvalidOperationException($"Invalid value specified for spawn mode property_ {SpawnMode}");
            }
        }

        Instantiate(SpawnableObject, _spawnLocation.position, Quaternion.identity, this.gameObject.transform);
    }

    public enum ObjectSpawnMode
    {
        Single = 0,
        Chronologically = 1,
        Random = 2
    }
}
