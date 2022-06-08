using System;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour, IPauseHandler
{
    public Gameplayer Gameplayer;
    public bool IsHaveBuff;

    public float Width
    {
        set { transform.localScale = new Vector3(value, transform.localScale.y); }
        get { return transform.localScale.x; }
    }

    private float _velocity = 13f;
    private float _boundary = 2.15f;
    private bool _isMovable = true;

    private void Update()
    {
        if (!_isMovable) return;

        if (Input.GetAxis("Horizontal") != 0)
            Move(Input.GetAxis("Horizontal"));
    }

    private void Move(float swipeDelta)
    {
        transform.Translate(Vector3.right * _velocity * swipeDelta * Time.deltaTime);

        if (transform.position.x < -_boundary)
        {
            transform.position = new Vector2(-_boundary, transform.position.y);
        }

        if (transform.position.x > _boundary)
        {
            transform.position = new Vector2(_boundary, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BuffPref buff))
        {
            buff.GetBuff().Apply();
            Gameplayer.PauseManager.Unregister(buff);
            Destroy(other.gameObject);
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

    public void SetPaused(bool isPaused)
    {
        _isMovable = !isPaused;
    }
}