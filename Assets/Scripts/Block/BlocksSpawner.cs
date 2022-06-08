using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    public GameObject prefabBlock;
    public float _maxColumn;
    public float _maxRow;

    private Vector3 _startSpawnPosition;
    private float _blockHeigth;
    private float _blockWeigth;

    [SerializeField]private float _offsetX;
    [SerializeField]private float _offsetY;
    
    private Vector3 _currentPosition;

    public void SpawnBlocks(ref List<Block> blocksList)
    {
        CalculateSizeImagePrefab();
        CalculatePointForParentCenter();
        for (int x = 0; x < _maxRow; x++)
        {
            _currentPosition.x = _startSpawnPosition.x;
            for (int y = 0; y < _maxColumn; y++)
            {
                GameObject go = Instantiate(prefabBlock.gameObject, _currentPosition,
                    Quaternion.identity, transform);
                go.name = x.ToString();
                _currentPosition.x = go.transform.localPosition.x + _blockWeigth + _offsetX;

                Block block = go.GetComponent<Block>();
                block.Line = x;
                blocksList.Add(block);
            }

            _currentPosition.y -= _offsetY + _blockHeigth;
        }
    }

    private void CalculateSizeImagePrefab()
    {
        var localScale = prefabBlock.transform.localScale;
        _blockHeigth = prefabBlock.GetComponent<SpriteRenderer>().size.y * localScale.y;
        _blockWeigth = prefabBlock.GetComponent<SpriteRenderer>().size.x * localScale.x;
    }

    private void CalculatePointForParentCenter()
    {
        float mainDistance = _maxColumn * _blockWeigth + (_maxColumn - 1) * _offsetX - 2 * _blockWeigth / 2;

        _startSpawnPosition.x = -mainDistance / 2;
        _startSpawnPosition.y = transform.position.y - _blockHeigth / 2;

        _currentPosition = _startSpawnPosition;
    }
}