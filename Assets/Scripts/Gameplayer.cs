using UnityEngine;

public class Gameplayer : MonoBehaviour
{
    public BlockController BlockController;
    public BallController BallController;
    public BuffSpawner BuffSpawner;
    public View View;
    public PauseManager PauseManager { get; private set; }

    private int _maxLife = 3;
    private int _lifeQty;

    private void Start()
    {
        PauseManager = new PauseManager();
        //SaveSystem.GetInstance().LoadData();
        View.ShowToast("Press 'Space' to start \n Your old Score "+SaveSystem.GetInstance().Data.Score);
        Play();
    }

    public void Restart()
    {
        ResetGame();
        Play();
    }

    public void Play()
    {
        _lifeQty = _maxLife;
        View.ChangeHealth(_maxLife, _lifeQty);

        BlockController.Init();
        BallController.Spawn();
    }

    public void FinishGame(bool isWin)
    {
        ResetGame();
        View.ShowFinish(isWin);
    }

    private void ResetGame()
    {
        StopAllCoroutines();
        BuffSpawner.Clear();
        BallController.Reset();
        BlockController.Reset();
    }

    public void DestroyPlayer()
    {
        _lifeQty--;
        View.ChangeHealth(_maxLife, _lifeQty);
        if (_lifeQty <= 0)
        {
            FinishGame(false);
            return;
        }

        BallController.Respawn();
        BuffSpawner.Clear();
    }

    public void UpdateScore(int value)
    {
        View.AddScore(value);
    }

    public Ball GetPlayer()
    {
        return BallController.GetPlayer();
    }

    private void OnApplicationQuit()
    {
        SaveSystem.GetInstance().SaveData();
    }
}