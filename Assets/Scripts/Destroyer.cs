using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Gameplayer Gameplayer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            Gameplayer.DestroyPlayer();
        
    }
}
