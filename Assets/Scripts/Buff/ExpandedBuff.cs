using UnityEngine;

public class ExpandedBuff : IBuff
{
    public TypeBuffEnum Type = TypeBuffEnum.EXPANDED;
    
    private Platform _platform;
    private float _time = 5f;

    private float _oldValue;
    private float _multiplayer = 2f;

    public ExpandedBuff(Platform platform)
    {
        _platform = platform;
    }
    
    public void Apply()
    {
        if (_platform.IsHaveBuff) return;
        _platform.IsHaveBuff = true;
        
        _oldValue = _platform.Width;
        _platform.Width = _oldValue * _multiplayer;
        _platform.CancelEffectByTime(Cancel,_time);
        Debug.Log("Aplly " + Type);
    }

    public void Cancel()
    {
        _platform.Width = _oldValue;
    }
}