using UnityEngine;

public class OneShootBuff : IBuff
{
    public TypeBuffEnum Type = TypeBuffEnum.ONE_SHOT;
    
    private Ball _ball;
    private float _time = 5f;

    private int _oldValue;
    private int _multiplayer = 10;

    public OneShootBuff(Ball ball)
    {
        _ball = ball;
    }
    
    public void Apply()
    {
        if (_ball.IsHaveBuff) return;
        _ball.IsHaveBuff = true;
        
        _oldValue = _ball.Damage;
        _ball.Damage = _oldValue * _multiplayer;
        _ball.CancelEffectByTime(Cancel,_time);
        Debug.Log("Aplly " + Type);
    }

    public void Cancel()
    {
        _ball.Damage = _oldValue;
        Debug.Log("Cancel buff " + Type);
    }
}