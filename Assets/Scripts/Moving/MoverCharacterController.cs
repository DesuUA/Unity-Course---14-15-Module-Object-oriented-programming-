using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class MoverCharacterController : ControllableMover
{
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public override void Direction(Vector3 direction)
    {
        
    }

    public void SetMovementCommand(Vector3 direction, bool isBoosting = false)
    {
        if (direction.sqrMagnitude < 0.001f) return;
        
        Vector3 directionXZ = new Vector3(direction.x, 0f, direction.z);
        
        ProcessMoveTo(directionXZ.normalized, isBoosting);
        
        ProcessRotateTo(directionXZ);
    }

    private void ProcessMoveTo(Vector3 direction, bool isBoosting)
    {
        float tempSpeed = speed;
        if (isBoosting) tempSpeed = boostMultiplier * tempSpeed;
        else tempSpeed = tempSpeed;
        
        _characterController.Move(direction * (tempSpeed * Time.deltaTime));
    }
    
    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        float step = Time.deltaTime * rotationSpeed;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
    }
}
