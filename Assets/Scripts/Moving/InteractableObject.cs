using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract bool Grab();
    public abstract bool Interact();

    protected virtual void Destroy()
    {
        if (Interact())
            Destroy(gameObject);
    }
    

}
