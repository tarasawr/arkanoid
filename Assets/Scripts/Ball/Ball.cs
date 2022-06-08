using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour, IPauseHandler
{
    public float Speed
    {
        set { _speed = value; }
        get { return _speed; }
    }

    public int Damage
    {
        set { _damageQty = value; }
        get { return _damageQty; }
    }

    public bool IsHaveBuff;

    private Rigidbody2D _rb;
    private int _damageQty = 1;
    private float _minSpeed = 3f;
    private float _speed = 10f;
    private bool _isMovable;
    private bool _isPause;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Push()
    {
        _isMovable = true;
        _rb.velocity = new Vector2(Random.Range(_minSpeed, _speed + 1), _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamage damage))
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector2 point = hit.point;
                //Instantiate(hitEffect, new Vector3(point.x, point.y, 0), Quaternion.identity);
            }
            //SH.PlaySound(1);
            damage.TakeDamage(_damageQty);
        }

        if (collision.collider.TryGetComponent(out Platform platform))
        {
            float PointX = 0;
            float forceX = 0;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                PointX = (hit.point.x - platform.transform.position.x) / (platform.transform.localScale.x / 2);
                forceX = (PointX > 0) ? Mathf.Clamp(PointX, 0, 1) : Mathf.Clamp(PointX, -1, 0);
            }

            _rb.velocity = new Vector2(forceX * _speed, _speed);
        }
    }

    public void CancelEffectByTime(Action action, float time)
    {
        StartCoroutine(Cancel(action, time));
    }

    private IEnumerator Cancel(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
        IsHaveBuff = false;
    }

    private void Update()
    {
        if (_isPause) return;

        if (Input.GetKey(KeyCode.Space) && !_isMovable)
            Push();
        
        if (_isMovable)
            if (_rb.velocity.y < _speed && _rb.velocity.y >= 0)
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            else if (_rb.velocity.y < 0 && _rb.velocity.y >= -_speed)
                _rb.velocity = new Vector2(_rb.velocity.x, -_speed);
    }

    public void SetPaused(bool isPaused)
    {
        _isPause = isPaused;

        if (!_isMovable)return;
      
        if (isPaused)
            _rb.velocity = Vector2.zero;
        else 
            Push();
    }
}