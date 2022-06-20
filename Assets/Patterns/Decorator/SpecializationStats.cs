using System;

public class SpecializationStats : StatsDecorator
{
    private readonly Specialization _specialization;

    public SpecializationStats(IStatsProvider wrappedEntity, Specialization specialization) : base(wrappedEntity)
    {
        _specialization = specialization;
    }

    protected override PlayerStats GetStatsInternal()
    {
        return _wrappedEntity.GetStats() + GetSpecStats(_specialization);
    }

    private PlayerStats GetSpecStats(Specialization specialization)
    {
        switch (specialization)
        {
            case Specialization.Warrior:
                return new PlayerStats()
                {
                    Strength = 10,
                    Agility = 6,
                    Intelligence = 3,
                    Stamina = 3,
                };
            case Specialization.Mage:
                return new PlayerStats()
                {
                    Strength = 20,
                    Agility = 6,
                    Intelligence = 3,
                    Stamina = 3,
                };
            case Specialization.Druid:
                return new PlayerStats()
                {
                    Strength = 1,
                    Agility = 24,
                    Intelligence = 3,
                    Stamina = 15,
                };
            default:
                throw new NotImplementedException($"RaceType {specialization} doesnt implemented!");
        }
    }
}