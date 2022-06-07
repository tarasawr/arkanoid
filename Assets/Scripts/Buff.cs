using UnityEngine;

public class Buff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            Debug.Log("TakeBuff " + tag);
            //Events.Buff?.Invoke(gameObject.tag);
            //SH.PlaySound(2);
            Destroy(gameObject);
        }
    }
}