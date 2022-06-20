using System;

public class RaceStats : IStatsProvider
{
    private readonly RaceType _raceType;

    public RaceStats(RaceType raceType)
    {
        _raceType = raceType;
    }

    public PlayerStats GetStats()
    {
        switch (_raceType)
        {
            case RaceType.ELF:
                return new PlayerStats()
                {
                    Strength = 10,
                    Agility = 6,
                    Intelligence = 3,
                    Stamina = 3,
                };
            case RaceType.ORC:
                return new PlayerStats()
                {
                    Strength = 10,
                    Agility = 6,
                    Intelligence = 3,
                    Stamina = 3,
                };
            case RaceType.GNOM:
                return new PlayerStats()
                {
                    Strength = 10,
                    Agility = 6,
                    Intelligence = 3,
                    Stamina = 3,
                };
            default:
                throw new NotImplementedException($"RaceType {_raceType} doesnt implemented!");
        }
    }
}