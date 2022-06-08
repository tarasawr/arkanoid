using UnityEngine;

public class Gameplayer : MonoBehaviour
{
    public BlockController BlockController;
    public BallController BallController;
    public Platform Platform;

    private void Start()
    {
        BlockController.Init();
        BallController.Spawn();
    }

    public void ActivateBuff(IBuff buff)
    {
        buff.Apply();
    }

    public Ball GetPlayer()
    {
        return BallController.GetPlayer();
    }
    public Platform GetPlatform()
    {
        return Platform;
    }
}