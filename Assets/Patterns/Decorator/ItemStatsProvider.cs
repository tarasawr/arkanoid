using System.Collections.Generic;
using UnityEngine;

public class ItemStatsProvider : StatsDecorator
{
    private readonly ItemDataBase _dataBase;
    public ItemStatsProvider(IStatsProvider wrappedEntity) : base(wrappedEntity)
    {
        _dataBase = Resources.Load<ItemDataBase>("Config/Items");
    }

    protected override PlayerStats GetStatsInternal()
    {
        //разобратся
        var stats = new PlayerStats();
        return _wrappedEntity.GetStats() + stats;
    }
}