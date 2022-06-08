using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamage
{
    public Action<Block> DeadAction;
    public int Line { set { _maxHealth = _health = value; } }

    private HealthColor _healthColor => GetComponent<HealthColor>();
    private float _health;
    private float _maxHealth;
    
    public void TakeDamage(int damageQty)
    {
        _health -= damageQty;
        _healthColor.Сhange(_health / _maxHealth);
        
        if (_health <= 0)
            DeadAction?.Invoke(this);
    }
}