using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject BlockPref;
    public Transform SpawnPoint;
    public Transform Parent;
    private int _maxRow = 4;
    private int _maxColumn = 4;
    private List<Block> _blocksList = new List<Block>();
    
    public void Spawn()
    {
        for (int x = 0; x < _maxRow; x++)
        {
            for (int y = 0; y < _maxColumn; y++)
            {
                GameObject go = Instantiate(BlockPref);
                go.transform.position = new Vector3(x,y,1f);
                _blocksList.Add(go.GetComponent<Block>());
            }
        }
    }
}
