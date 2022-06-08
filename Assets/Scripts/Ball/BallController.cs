using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject BallPref;
    public Transform PossSpawn;
    private Ball _player;

    public void Spawn()
    {
        GameObject go =
            Instantiate(BallPref, PossSpawn.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        _player = go.GetComponent<Ball>();
    }

    public Ball GetPlayer()
    {
        return _player;
    }
}