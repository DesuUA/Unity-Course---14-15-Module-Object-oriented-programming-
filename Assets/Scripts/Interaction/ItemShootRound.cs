using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShootRound : InteractableItem
{
    private BulletSpawnPoint _bulletSpawnPoint;
    private bool _hasSpawnPoint;
    
    private void Start()
    {
        _bulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>();
        if (_bulletSpawnPoint == null)
            Debug.LogError($"{this}: Точка спавна пули не найдена");
        else
            _hasSpawnPoint = true;
    }
    
    public override void Interact()
    {
        if (_hasSpawnPoint)
        {
            
        }
    }
}
