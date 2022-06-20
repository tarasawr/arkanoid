public struct PlayerStats
{
    public float Strength { get; set; }
    public float Agility { get; set; }
    public float Intelligence { get; set; }
    public float Stamina { get; set; }

    public static PlayerStats operator +(PlayerStats a, PlayerStats b)
    {
        return new PlayerStats()
        {
            Strength = a.Strength + b.Strength,
            Agility = a.Agility + b.Agility,
            Intelligence = a.Intelligence + b.Intelligence,
            Stamina = a.Stamina + b.Stamina
        };
    }

    public static PlayerStats operator *(PlayerStats a, float m)
    {
        return new PlayerStats()
        {
            Strength = a.Strength * m,
            Agility = a.Agility * m,
            Intelligence = a.Intelligence * m,
            Stamina = a.Stamina * m
        };
    }
}