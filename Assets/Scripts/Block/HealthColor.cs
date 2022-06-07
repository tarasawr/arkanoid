using UnityEngine;

public class HealthColor : MonoBehaviour
{
    private SpriteRenderer _sprite => GetComponent<SpriteRenderer>();
    private Gradient _gradient;

    private void Awake()
    {
        _gradient = new Gradient();

        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = _sprite.color;
        colorKey[1].time = 1.0f;

        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 1.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.0f;

        _gradient.SetKeys(colorKey, alphaKey);
    }

    public void Сhange(float percent)
    {
        Debug.Log(percent);
        _sprite.color = _gradient.Evaluate(percent);
    }
}