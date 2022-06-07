using UnityEngine;

public class Gameplayer : MonoBehaviour
{
    
   public BlockController BlockController;
   public BallController BallController;

   private Transform _platform;
   private GameObject _ballprefab;
    
    private int _maxHeart = 3;

    private void Start()
    {
        BlockController.Spawn();
        BallController.Spawn();
    }
    
    public void DestroyBlock(GameObject block)
    {
     
    }


    public void DestroyBall(GameObject ball)
    {
        //_balls.Remove(ball);

        if (_maxHeart > 0)
        {
            _maxHeart--;
            //UIHeart.HeartDisplay(Heart);
           // CreateBall();
        }
    }
}