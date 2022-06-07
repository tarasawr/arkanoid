using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamage
{
    public float MaxHealth
    {
        set
        {
            _maxHealth = _health = value;
            _healthColor.Сhange(_health / _maxHealth);
        }
    }

    public Action<Block> DeadAction;
    public Buff Buff;

    private HealthColor _healthColor => GetComponent<HealthColor>();
    private float _health;
    private float _maxHealth;
    private GameObject[] buff;

    public void TakeDamage(int damageQty)
    {
        _health -= damageQty;
        _healthColor.Сhange(_health / _maxHealth);
        
        if (_health <= 0)
            DeadAction?.Invoke(this);
    }
}