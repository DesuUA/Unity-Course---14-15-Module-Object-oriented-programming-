using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 5f;

    private Bullet(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
        
        Rigidbody bulletBody = GetComponent<Rigidbody>();
        bulletBody.AddForce(direction * _speed, ForceMode.Impulse);
        
        Destroy(gameObject, _lifeTime);
    }
}
