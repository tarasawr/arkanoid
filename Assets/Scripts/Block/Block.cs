using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamage
{
    public Action<Block> DeadAction;

    public int Score
    {
        get { return _score; }
        private set { _score = value; }
    }

    private HealthColor _healthColor => GetComponent<HealthColor>();
    private float _health;
    private float _maxHealth;
    private int _maxRows;
    private int _score;

    public void SetData(int maxLine, int currentLine)
    {
        _health = _score = currentLine;
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