using UnityEngine;

public class Client : IBuffVisitor
{
    public void Visit(Expanded weapon)
    {
        Debug.Log(weapon.GetType().Name);
    }

    public void Visit(DoubleDamage weapon)
    {
        Debug.Log(weapon.GetType().Name);
    }

    public void Visit(OneShot weapon)
    {
        Debug.Log(weapon.GetType().Name);
    }

    public void Visit(SlowSpeed weapon)
    {
        Debug.Log(weapon.GetType().Name);
    }
}