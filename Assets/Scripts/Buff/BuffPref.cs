using UnityEngine;

public class BuffPref : MonoBehaviour
{
    public Sprite Icon
    {
        private get { return Icon; }
        set
        {
            Icon = value;
            _sp.sprite = Icon;
        }
    }

    private float _speed = 1f;
    private IBuff _buff;

    private SpriteRenderer _sp;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    public void SetBuff(IBuff buff)
    {
        _buff = buff;
    }

    public IBuff GetBuff()
    {
        return _buff;
    }

    private void Update()
    {
        transform.position += Vector3.down * (_speed * Time.deltaTime);
    }
}