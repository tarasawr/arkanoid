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
            block.MaxHealth = x + 1;
            block.DeadAction = DeadBlock;
            block.Buff = GetRndBuff();
            _blocksList.Add(block);
        }
    }

    private void DeadBlock(Block block)
    {
        block.Buff.Apply();
        Destroy(block.gameObject);
    }

    private Buff GetRndBuff()
    {
        float rnd = Random.value;
        if (rnd < 0.7f)
        {
            int type = Random.Range(0, 2);
            switch (type)
            {
                default:
                case 0:
                    return new DoubleDamageBuff();
                case 1:
                    return new ExpandedBuff();
                case 2:
                    return new OneShootBuff();
                case 3:
                    return new SlowSpeedBuff();
            }
        }
        else
        {
            return new EmptyBuff();
        }
    }
}