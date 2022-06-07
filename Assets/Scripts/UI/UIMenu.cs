using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void OpenLevel(string lvl)
    {
        SceneManager.LoadScene("Level" + lvl);
    }
}