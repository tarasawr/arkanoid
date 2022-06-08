using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuffSpawner : MonoBehaviour
{
    public Gameplayer Gameplayer;
    public Platform Platform;

    [Range(0, 1)] public float Chance;

    public GameObject BuffPref;

    public void Spawn(Transform trnsf)
    {
        Gameplayer.PauseManager.Register(Platform);
        float rnd = Random.value;
        if (rnd <= Chance)
        {
            GameObject go = Instantiate(BuffPref, trnsf.position, Quaternion.identity);
            //Debug.Log(go.name);
            BuffPref buffPref = go.GetComponent<BuffPref>();
            buffPref.SetBuff(GetRndBuff());
            Gameplayer.PauseManager.Register(buffPref);
        }
    }

    private IBuff GetRndBuff()
    {
        string[] enums = Enum.GetNames(typeof(TypeBuffEnum));
        string rnd = enums[Random.Range(0, enums.Length)];

        Ball ball = Gameplayer.GetPlayer();

        switch (rnd)
        {
            case nameof(TypeBuffEnum.ONE_SHOT):
                return new OneShootBuff(ball);
            case nameof(TypeBuffEnum.SLOW_SPEED):
                return new SlowSpeedBuff(ball);
            case nameof(TypeBuffEnum.DOUBLE_DAMAGE):
                return new DoubleDamageBuff(ball);
            case nameof(TypeBuffEnum.EXPANDED):
                return new ExpandedBuff(Platform);
            default:
                Debug.Log("Enum is not finded " + rnd);
                return new EmptyBuff();
        }
    }
}