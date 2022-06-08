using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private List<Block> _blocksList = new List<Block>();
    public BlocksSpawner BlocksSpawner;
    public BuffSpawner BuffSpawner;
    
    public void Init()
    {
        BlocksSpawner.SpawnBlocks(ref _blocksList);
        
        foreach (Block block in _blocksList)
            block.DeadAction += DeadBlock;
    }
    
    private void DeadBlock(Block block)
    {
        BuffSpawner.Spawn(block.transform);
        Destroy(block.gameObject);
    }
}