using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemAddHealth : InteractableItem
{
    [SerializeField] private float _healthToAdd = 10f;
    
    public override void Interact()
    {
        
    }
}
