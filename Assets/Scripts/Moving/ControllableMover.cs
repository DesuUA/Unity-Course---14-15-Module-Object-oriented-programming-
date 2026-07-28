using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ControllableMover : Mover
{
    [SerializeField] protected float boostMultiplier = 2f;
    [SerializeField] protected float rotationSpeed = 180f;
    
    public bool isBoosting;
    
    protected float CurrentSpeed => isBoosting ? speed * boostMultiplier : speed;
    
    public void SetSpeedBoost(bool enableBoost)
    {
        isBoosting = enableBoost;
    }
}