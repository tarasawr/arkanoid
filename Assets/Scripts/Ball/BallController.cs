using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject BallPref;
    public Transform PossSpawn;

    public void Spawn()
    {
        GameObject ballPref =
            Instantiate(BallPref, PossSpawn.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    }
}
