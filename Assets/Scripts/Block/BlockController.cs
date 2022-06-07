using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject BlockPref;
    public Transform Parent;

    private int _maxRow = 4;
    private int _maxColumn = 4;
    private float _startPointX;
    private List<Block> _blocksList = new List<Block>();
    private Transform _blockTransfrom;

    private void Awake()
    {
        _blockTransfrom = BlockPref.GetComponent<Transform>();
    }

    public void Spawn()
    {
        _startPointX = Parent.position.x - _blockTransfrom.localScale.x * _maxColumn / 2;

        for (int x = 0; x < _maxRow; x++)
        for (int y = 0; y < _maxColumn; y++)
        {
            GameObject go = Instantiate(BlockPref, Parent);
            go.transform.localPosition += new Vector3(_startPointX + x, y, 1f);
            Block block = go.GetComponent<Block>();
            block.MaxHealth = _maxRow;
            _blocksList.Add(block);
        }
    }
}