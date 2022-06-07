using UnityEngine;

public class Block : MonoBehaviour, IDamageable
{
    private Gameplayer _gameplayer;
    private SwitchColor SwitchColor => GetComponent<SwitchColor>();
    
    private int _health;
    private int _maxHealth;

    private GameObject[] buff;

    private void Start()
    {
        SwitchColor.ColorСhange(_health);
        _maxHealth = _health;
    }
    
    public void TakingDamage(int Damage) 
    {
        _health -= Damage;
        SwitchColor.ColorСhange(_health);
        if (_health <= 0 && _maxHealth > 0)
        {
            Destroy();
        }
    }
    
    private void Destroy()
    {
        _gameplayer.DestroyBlock(gameObject);
        Destroy(gameObject);

        if (buff.Length != 0)
        {
            float chance = Random.Range(0,101);
            if (chance <= 15f) 
            {
                int count = Random.Range(0, buff.Length);
                Instantiate(buff[count], transform.position, Quaternion.identity);
            }
        }
    }
}
