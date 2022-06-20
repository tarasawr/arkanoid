public class HolyLightStats : StatsDecorator
{
    public HolyLightStats(IStatsProvider wrappedEntity) : base(wrappedEntity) { }

    protected override PlayerStats GetStatsInternal()
    {
        return _wrappedEntity.GetStats() * 2;
    }
}