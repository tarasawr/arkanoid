using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Gameplayer Gameplayer;

    public Text ScoreText;
    public Text InfoText;
    public Text FinishInfoText;
    public GameObject WinPanel;
    public Slider HealthSlider;

    private int _score = default;
    private Color _defaultColorInfoText;

    private void Start()
    {
        _defaultColorInfoText = InfoText.color;
        UpdateScoreUi();
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreUi();
    }

    public void UpdateScoreUi()
    {
        ScoreText.text = _score.ToString();
    }

    public void Restart_OnClick()
    {
        WinPanel.SetActive(false);
        Gameplayer.Restart();
    }

    public void Pause_OnClick()
    {
        bool isPause = Gameplayer.PauseManager.IsPaused;
        Gameplayer.PauseManager.SetPaused(!isPause);
    }

    public void ShowFinish(bool isWin)
    {
        WinPanel.SetActive(true);
        
        string tmp = default;
        if (isWin)
            tmp = "Krasavchic, your score " + _score + "\n Common score " +
                  SaveSystem.GetInstance().Data.Score;
        else
            tmp = "LoL, your score " + _score + "\n Common score " +
                  SaveSystem.GetInstance().Data.Score;
        FinishInfoText.text = tmp;
        
        SaveSystem.GetInstance().Data.Score += _score;
        _score = 0;
        UpdateScoreUi();
    }

    public void ChangeHealth(int maxLife, int qtyLife)
    {
        HealthSlider.value = (float) qtyLife / maxLife;
    }

    public void ShowToast(string message)
    {
        InfoText.gameObject.SetActive(true);
        InfoText.color = _defaultColorInfoText;
        InfoText.text = message;
        StartCoroutine(FadeText(1.5f, InfoText));
    }

    private IEnumerator FadeText(float t, Text i)
    {
        var color = i.color;
        color = new Color(color.r, color.g, color.b, 1);
        i.color = color;
        while (i.color.a > 0.0f)
        {
            var color1 = i.color;
            color1 = new Color(color1.r, color1.g, color1.b, color1.a - (Time.deltaTime / t));
            i.color = color1;
            yield return null;
        }

        i.gameObject.SetActive(false);
    }
}