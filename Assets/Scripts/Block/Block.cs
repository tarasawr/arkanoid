using System;
using System.Collections;
using System.Collections.Generic;
using Papae.UnitySDK.Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Block
{
    public class Block : MonoBehaviour, IDamage
    {
        public Action<Block> DeadAction;

        public int Score
        {
            get { return _score; }
            private set { _score = value; }
        }

        private HealthColor _healthColor;
        private SpriteRenderer _spriteRenderer;

        private int _health;
        private int _maxHealth;
        private int _maxRows;
        private int _score;
        private int _line;

        private AudioClip _touchClip;

        private Sprite _full;
        private Sprite _brocken;

        private string _spriteNameBrocken;
        private string _spriteNameFull;

        private void Awake()
        {
            _healthColor = GetComponent<HealthColor>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetData(Data data)
        {
            _maxHealth = data.MaxHealth;
            _line = data.CurrentLine;
             Score = data.Score;
            _spriteNameBrocken = data.SpriteNameBrocken;
            _spriteNameFull = data.SpriteNameFull;
            
            _health = _maxHealth;

            Load();
        }

        public void TakeDamage(int damageQty)
        {
            AudioManager.Instance.PlayOneShot(_touchClip);
            _health -= damageQty;
            float percent = (float) _health / _maxHealth;

            _healthColor.Сhange(percent);

            if (percent < 0.5f)
                _spriteRenderer.sprite = _brocken;

            if (_health <= 0)
                DeadAction?.Invoke(this);
        }

        private void  Load()
        {
            AsyncOperationHandle<Sprite> full = Addressables.LoadAsset<Sprite>(_spriteNameFull);
            AsyncOperationHandle<Sprite> brocken = Addressables.LoadAsset<Sprite>(_spriteNameBrocken);
            AsyncOperationHandle<AudioClip> touchClip = Addressables.LoadAsset<AudioClip>("clip" + _line);
            full.Completed += SpriteFull;
            brocken.Completed += SpriteBrocken;
            touchClip.Completed += AudioClip;
        }
        
        private void SpriteFull(AsyncOperationHandle<Sprite> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                _full = handle.Result;

            _spriteRenderer.sprite = _full;
        }

        private void SpriteBrocken(AsyncOperationHandle<Sprite> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                _brocken = handle.Result;
        }

        private void AudioClip(AsyncOperationHandle<AudioClip> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                _touchClip = handle.Result;
        }
    }
}