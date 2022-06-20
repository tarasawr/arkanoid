public class Player
{
    private RaceType _race = RaceType.ORC;
    private Specialization _spec = Specialization.Warrior;
    private IStatsProvider _provider;

    public Player()
    {
        _provider = new RaceStats(_race);
        _provider = new SpecializationStats(_provider, _spec);
        _provider = new ItemStatsProvider(_provider);
        _provider = new HolyLightStats(_provider);
        
    }
}