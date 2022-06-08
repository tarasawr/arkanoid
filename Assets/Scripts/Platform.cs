using System;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Gameplayer Gameplayer;
    public Transform rightLimitPosition;
    public Transform leftLimitPosition;

    public bool IsHaveBuff;

    public float Width
    {
        set
        {
            transform.localScale = new Vector3(value,transform.localScale.y);
        }
        get { return transform.localScale.x; }
    }

    private float Velocity = 15f;
    private float _rightLimit;
    private float _leftLimit;
    private float _lengthPlatform;
    private float _currDiff = 0f;

    private void Start()
    {
        _rightLimit = rightLimitPosition.position.x;
        _leftLimit = leftLimitPosition.position.x;
        _lengthPlatform = Mathf.Abs(transform.localScale.x);
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            Move(Input.GetAxis("Horizontal"));

        if (Input.touches.Length > 0)
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector2 swipeDelta = Input.touches[0].position;
                MoveOnMobile(swipeDelta);
            }
    }

    private void Move(float swipeDelta)
    {
        transform.Translate(Vector3.right * Velocity * swipeDelta * Time.deltaTime);
        transform.position =
            new Vector3(
                Mathf.Clamp(transform.position.x, _leftLimit + _lengthPlatform / 2, _rightLimit - _lengthPlatform / 2),
                transform.position.y, transform.position.z);
    }

    private void MoveOnMobile(Vector2 swipeDelta)
    {
        float weightRoad = Mathf.Abs(_rightLimit - _lengthPlatform / 2) + Mathf.Abs(_leftLimit + _lengthPlatform / 2);
        float Position = (swipeDelta.x / Screen.width) * weightRoad - weightRoad / 2;
        _currDiff = Mathf.MoveTowards(_currDiff, Position, Velocity * Time.deltaTime);
        transform.position = new Vector3(_currDiff, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out BuffPref buff))
        {
            Gameplayer.ActivateBuff(buff.GetBuff());
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
}