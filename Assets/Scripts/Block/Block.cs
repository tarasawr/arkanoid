using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamage
{
    public Action<Block> DeadAction;

    private HealthColor _healthColor => GetComponent<HealthColor>();
    private float _health;
    private float _maxHealth;
    private int _maxRows;

    public void SetData(int maxLine, int currentLine)
    {
        _health  = currentLine;
        _maxHealth = maxLine;
        _healthColor.SetColorByLine(maxLine, currentLine);
    }

    public void TakeDamage(int damageQty)
    {
        _health -= damageQty;
        _healthColor.Сhange(_health / _maxHealth);

        if (_health <= 0)
            DeadAction?.Invoke(this);
    }
}