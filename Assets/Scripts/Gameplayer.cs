using UnityEngine;

public class Gameplayer : MonoBehaviour
{
    public BlockController BlockController;
    public BallController BallController;

    private void Start()
    {
        BlockController.Spawn();
        BallController.Spawn();
    }
}