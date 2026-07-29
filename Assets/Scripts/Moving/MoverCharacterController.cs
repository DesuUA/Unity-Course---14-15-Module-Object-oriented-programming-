using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class MoverCharacterController : Mover
{
    private CharacterController _characterController;
    private Vector3 _inputDirection;
    private float _verticalVelocity;
    private bool _jumpRequest;
    
    private const float Gravity = -9.81f;
    private const float GroundedGravity = -2f;

    protected override void Start()
    {
        base.Start();
        _characterController = GetComponent<CharacterController>();
    }

    public override void SetDirection(Vector3 direction)
    {
        _inputDirection = new Vector3(direction.x, 0f, direction.z).normalized;
    }
    
    public override void SetJump(bool jump)
    {
        if (jump && _characterController.isGrounded)
        {
            _jumpRequest = true;
        }
    }

    private void Update()
    {
        ApplyGravityAndJump();
        
        ProcessMoveTo();
        
        if (_inputDirection != Vector3.zero) 
            ProcessRotateTo(_inputDirection);
    }

    private void ApplyGravityAndJump()
    {
        if (_characterController.isGrounded)
        {
            if (_verticalVelocity < 0)
            {
                _verticalVelocity = GroundedGravity;
            }

            if (_jumpRequest)
            {
                _verticalVelocity = Mathf.Sqrt(jumpForce * -2f * Gravity);
                _jumpRequest = false;
            }
        }
        else
        {
            _jumpRequest = false; 
            _verticalVelocity += Gravity * Time.deltaTime;
        }
    }

    private void ProcessMoveTo()
    {
        Vector3 finalVelocity = (_inputDirection * CurrentSpeed) + (Vector3.up * _verticalVelocity);
        
        _characterController.Move(finalVelocity * Time.deltaTime);
    }
    
    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float step = Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
    }
}