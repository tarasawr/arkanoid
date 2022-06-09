using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BuffPref : MonoBehaviour, IPauseHandler
{
    private float _speed = 1f;
    private IBuff _buff;
    private bool _isPause;

    private SpriteRenderer _sp;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    public void SetBuff(IBuff buff,string type)
    {
        _buff = buff;
        Load(type);
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

    private void Load(string type)
    {
        AsyncOperationHandle<Sprite> icon = Addressables.LoadAsset<Sprite>(type);
        icon.Completed += Icon;
    }

    private void Icon(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            _sp.sprite = handle.Result;
    }
}