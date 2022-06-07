using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    private SpriteRenderer _sprite =>GetComponent<SpriteRenderer>();

    private Color[] Colors = new Color[11]
    {
        new Color(0f, 0f, 0f),
        new Color(1, 0f, 0f),
        new Color(1f, 0.5f, 0f),
        new Color(1f, 1f, 0f),
        new Color(0f, 1f, 0f),
        new Color(0f, 1f, 1f),
        new Color(0f, 0f, 1f),
        new Color(1f, 0f, 1f),
        new Color(1f, 0.5f, 1f),
        new Color(0f, 0f, 0f),
        new Color(1f, 1f, 1f),
    };

    public void ColorСhange(int numColor)
    {
        if (numColor < 0 || numColor >= Colors.Length)
            _sprite.color = new Color(1f, 1f, 1f, 0.7f);
        else
            _sprite.color = Colors[numColor];
    }
}