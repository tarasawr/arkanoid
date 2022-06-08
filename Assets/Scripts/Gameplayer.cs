using UnityEngine;

public class Gameplayer : MonoBehaviour
{
    public BlockController BlockController;
    public BallController BallController;
    public View View;
    public PauseManager PauseManager { get; private set; }

    private void Start()
    {
        PauseManager = new PauseManager();
        Play();
    }

    public void Restart()
    {
        ResetGame();
        Play();
    }

    public void Play()
    {
        BlockController.Init();
        BallController.Spawn();
    }

    public void FinishGame()
    {
        View.ShowWin();
    }

    private void ResetGame()
    {
        BallController.Reset();
        BlockController.Reset();
    }

    public Ball GetPlayer()
    {
        return BallController.GetPlayer();
    }
}