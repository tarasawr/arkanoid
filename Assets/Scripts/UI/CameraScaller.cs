using UnityEngine;

public class CameraScaller : MonoBehaviour
{
    private bool _isHorizontal = false;
    private const float SizeX = 1920f;
    private const float SizeY = 1080f;
    private float _targetSizeX;
    private float _targetSizeY;
    private float _halfSize = 320f;

    private void Awake()
    {
        _targetSizeX = _isHorizontal ? SizeX : SizeY;
        _targetSizeY = _isHorizontal ? SizeY : SizeX;

        CameraResize();
    }

    private void CameraResize()
    {
        float screenRatio = (float) Screen.width / Screen.height;
        float targetRatio = _targetSizeX / _targetSizeY;

        if (screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 1f)
    {
        Camera.main.orthographicSize = _targetSizeY / _halfSize * differentSize;
    }
}