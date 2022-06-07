using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Gameplayer GamePlayHandler;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ball")) 
        {
            GamePlayHandler.DestroyBall(collision.gameObject);
        }

        Destroy(collision.gameObject);
    }
}
