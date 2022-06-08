using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Gameplayer Gameplayer;

    public Text ScoreText;
    public GameObject WinPanel;

    public void Restart_OnClick()
    {
        Gameplayer.Restart();
    }

    public void Pause_OnClick()
    {
        Debug.Log(Gameplayer.PauseManager.IsPaused);
        bool isPause = Gameplayer.PauseManager.IsPaused;
        Gameplayer.PauseManager.SetPaused(!isPause);
    }

    public void ShowWin()
    {
        WinPanel.SetActive(true);
    }
}