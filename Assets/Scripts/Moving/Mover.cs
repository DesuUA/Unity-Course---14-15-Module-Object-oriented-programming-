using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    public abstract void Direction(Vector3 direction);

}
