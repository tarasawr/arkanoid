using UnityEngine;

namespace Block
{
    public class HealthColor : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private Gradient _gradient;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _gradient = new Gradient();

            GradientColorKey[] colorKey = new GradientColorKey[2];
            var color = _sprite.color;
            colorKey[0].color = color;
            colorKey[0].time = 1.0f;
            colorKey[1].color = color;
            colorKey[1].time = 1.0f;

            GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 1.0f;
            alphaKey[1].alpha = 0.2f;
            alphaKey[1].time = 0.0f;

            _gradient.SetKeys(colorKey, alphaKey);
        }

        public void Сhange(float percent)
        {
            _sprite.color = _gradient.Evaluate(percent);
        }
    }
}