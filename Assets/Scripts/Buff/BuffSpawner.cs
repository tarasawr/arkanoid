using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuffSpawner : MonoBehaviour
{
    public Gameplayer Gameplayer;
    public Platform Platform;

    [Range(0, 1)] public float Chance;

    public GameObject BuffPref;
    private List<BuffPref> _buffPrefsList = new List<BuffPref>();

    public void Spawn(Transform trnsf)
    {
        Gameplayer.PauseManager.Register(Platform);

        if (Random.value <= Chance)
        {
            GameObject go = Instantiate(BuffPref, trnsf.position, Quaternion.identity);

            BuffPref buffPref = go.GetComponent<BuffPref>();
            string[] enums = Enum.GetNames(typeof(TypeBuffEnum));
            string type = enums[Random.Range(0, enums.Length)];
            IBuff buff = GetRndBuff(type);
            buffPref.SetBuff(buff, type);
            Gameplayer.PauseManager.Register(buffPref);
            _buffPrefsList.Add(buffPref);
        }
    }

    public void DestroyBuff(BuffPref buffPref)
    {
        Gameplayer.PauseManager.Unregister(buffPref);
        _buffPrefsList.Remove(buffPref);
        Destroy(buffPref.gameObject);
    }

    public void Clear()
    {
        foreach (BuffPref buffPref in _buffPrefsList)
        {
            Gameplayer.PauseManager.Unregister(buffPref);
            Destroy(buffPref.gameObject);
        }

        _buffPrefsList.Clear();
    }

    private IBuff GetRndBuff(string type)
    {
        Ball ball = Gameplayer.GetPlayer();

        switch (type)
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
                Debug.Log("Enum is not finded " + type);
                return new EmptyBuff();
        }
    }
}