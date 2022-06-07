using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _damageQty = 1;

    private float minspeed = 3f;
    private float speed = 5f;

    private int damageBonus = 2;
    private int minDamage = 1;
    private int maxDamage = 10;

    private bool _isActive = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void PunchBall()
    {
        if (!_isActive)
        {
            _rb.velocity = new Vector2(Random.Range(minspeed, speed + 1), speed);
            _isActive = true;
        }
    }

    private void IncreasedDamage(string buff)
    {
        if (buff.Equals("2xDamage"))
        {
            _damageQty = Mathf.Clamp(_damageQty * damageBonus, minDamage, maxDamage);
        }

        StartCoroutine(ReductionDamage());
    }

    private IEnumerator ReductionDamage()
    {
        yield return new WaitForSeconds(10);
        _damageQty = Mathf.Clamp(_damageQty / damageBonus, minDamage, maxDamage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamage IDamage))
        {
            Debug.Log("Hit");

            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector2 point = hit.point;
                // Instantiate(hitEffect, new Vector3(point.x, point.y, 0), Quaternion.identity);
            }

            //SH.PlaySound(1);
            IDamage.TakeDamage(_damageQty);
        }

        if (collision.collider.TryGetComponent(out Platform platform))
        {
            Debug.Log("Platform");

            float PointX = 0;
            float forceX = 0;

            foreach (ContactPoint2D hit in collision.contacts)
            {
                PointX = (hit.point.x - platform.transform.position.x) / (platform.transform.localScale.x / 2);
                forceX = (PointX > 0) ? Mathf.Clamp(PointX, 0, 1) : Mathf.Clamp(PointX, -1, 0);
            }

            _rb.velocity = new Vector2(forceX * speed, speed);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            PunchBall();

        if (Input.touches.Length > 0)
            if (Input.touches[0].phase == TouchPhase.Moved)
                PunchBall();

        if (_isActive)
            if (_rb.velocity.y < minspeed && _rb.velocity.y >= 0)
                _rb.velocity = new Vector2(_rb.velocity.x, minspeed);
            else if (_rb.velocity.y < 0 && _rb.velocity.y >= -minspeed)
                _rb.velocity = new Vector2(_rb.velocity.x, -minspeed);
    }
}