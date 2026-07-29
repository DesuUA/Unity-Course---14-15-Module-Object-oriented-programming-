using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class InteractableItem : MonoBehaviour
{
    public bool Grabbed { get; set; }
    public abstract void Interact();
}