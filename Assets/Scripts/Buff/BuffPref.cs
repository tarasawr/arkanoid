using UnityEngine;

public class BuffPref : MonoBehaviour, IPauseHandler
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
    private bool _isPause;

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
        if (_isPause) return;

        transform.position += Vector3.down * (_speed * Time.deltaTime);
    }

    public void SetPaused(bool isPaused)
    {
        _isPause = !isPaused;
    }
}