using UnityEngine;

public class SlowSpeedBuff : IBuff
{
    public TypeBuffEnum Type = TypeBuffEnum.SLOW_SPEED;
    private Ball _ball;

    private float _time = 5f;
    private float _oldValue;

    public SlowSpeedBuff(Ball ball)
    {
        _ball = ball;
    }

    public void Apply()
    {
        if (_ball.IsHaveBuff) return;
        _ball.IsHaveBuff = true;

        _oldValue = _ball.Speed;
        _ball.Speed = _oldValue / 2;
        _ball.CancelEffectByTime(Cancel, _time);
    }

    public void Cancel()
    {
        _ball.Speed = _oldValue;
        Debug.Log("Cancel buff " + Type);
    }
}