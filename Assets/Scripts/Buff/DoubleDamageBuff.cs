using UnityEngine;

public class DoubleDamageBuff : IBuff
{
    public TypeBuffEnum Type = TypeBuffEnum.DOUBLE_DAMAGE;

    private Ball _ball;
    private float _time = 5f;

    private int _oldValue;

    public DoubleDamageBuff(Ball ball)
    {
        _ball = ball;
    }
    
    public void Apply()
    {
        if (_ball.IsHaveBuff) return;
        _ball.IsHaveBuff = true;
        
        _oldValue = _ball.Damage;
        _ball.Damage = _oldValue * 2;
        _ball.CancelEffectByTime(Cancel,_time);
        Debug.Log("Aplly " + Type);
    }

    public void Cancel()
    {
        _ball.Damage = _oldValue;
        Debug.Log("Cancel buff " + Type);
    }
}