using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys object when triggering collider
/// Destroy all objects / only objects with matching tags
/// Set DestroyParent to specifiy wheter the colliding gameObject or its parent will be destroyed
/// </summary>
public class ObjectDestroyer : MonoBehaviour {

    public bool DestroyTaggedOnly = true;
    public List<string> Tags;

    public bool DestroyParent;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject objToDestroy = DestroyParent ? collision.gameObject.transform.parent.gameObject : collision.gameObject;

        if (!DestroyTaggedOnly)
            Destroy(objToDestroy);
        else if (Tags.Contains(collision.gameObject.tag))
            Destroy(objToDestroy);
    }
}
