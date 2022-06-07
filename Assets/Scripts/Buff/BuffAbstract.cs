using UnityEngine;

public abstract class Buff
{
    public enum TypeBuff
    {
        DOUBLE_DAMAGE,EXPANDED,ONESHOT
    }
    public virtual void Apply()
    {
       
    }
}