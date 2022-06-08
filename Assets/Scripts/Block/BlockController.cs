using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public BlocksSpawner BlocksSpawner;
    public BuffSpawner BuffSpawner;
    public Gameplayer Gameplayer;

    private List<Block> _blocksList = new List<Block>();

    public void Init()
    {
        BlocksSpawner.SpawnBlocks(ref _blocksList);

        foreach (Block block in _blocksList)
            block.DeadAction += DeadBlock;
    }

    private void DeadBlock(Block block)
    {
        BuffSpawner.Spawn(block.transform);
        _blocksList.Remove(block);
        Destroy(block.gameObject);
        CheckFinish();
    }

    public void Reset()
    {
        foreach (Block block in _blocksList)
            Destroy(block.gameObject);

        _blocksList.Clear();
    }

    private void CheckFinish()
    {
        if (_blocksList.Count <= 0)
            Gameplayer.FinishGame();
    }
}