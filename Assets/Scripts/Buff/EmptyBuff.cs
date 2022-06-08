using UnityEngine;

public class EmptyBuff : IBuff
{
    public  void Apply() { Debug.Log("Empty"); }
    public void Cancel() { }
}