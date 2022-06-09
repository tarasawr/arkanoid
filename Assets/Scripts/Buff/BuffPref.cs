using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BuffPref : MonoBehaviour, IPauseHandler
{
    private float _speed = 1f;
    private IBuff _buff;
    private bool _isPause;

    private SpriteRenderer _sp;
    private Sprite _icon;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    public void SetBuff(IBuff buff, string type)
    {
        _buff = buff;
        StartCoroutine(Load(type));
    }

    public IBuff GetBuff()
    {
        return _buff;
    }

    private void Update()
    {
        if (_isPause) return;

        transform.position += Vector3.down * (_speed * Time.deltaTime);
    }

    public void SetPaused(bool isPaused)
    {
        _isPause = isPaused;
    }

    private IEnumerator Load(string type)
    {
        AsyncOperationHandle<Sprite> icon = Addressables.LoadAssetAsync<Sprite>(type);
        yield return icon;
        icon.Completed += Icon;
    }

    private void Icon(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            _sp.sprite = _icon = handle.Result;
    }

    void OnDestroy()
    {
        if (_icon != null)
            Addressables.Release(_icon);
    }
}