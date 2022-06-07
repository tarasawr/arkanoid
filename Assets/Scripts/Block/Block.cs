using UnityEngine;
using Random = UnityEngine.Random;

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

    private HealthColor _healthColor => GetComponent<HealthColor>();

    private float _health;
    private float _maxHealth;

    private GameObject[] buff;
   
    
    public void TakeDamage(int damageQty)
    {
        
        _health -= damageQty;
        Debug.Log(_health + " " + _maxHealth);
        _healthColor.Сhange(_health / _maxHealth);

        if (_health <= 0)
            Destroy();
    }

    public void Destroy()
    {
        InitBuff();
        Destroy(gameObject);
    }

    private void InitBuff()
    {
        float rnd = Random.value;
        if (rnd < 0.5f)
        {
            int count = Random.Range(0, buff.Length);
            Instantiate(buff[count], transform.position, Quaternion.identity);
        }
    }
}