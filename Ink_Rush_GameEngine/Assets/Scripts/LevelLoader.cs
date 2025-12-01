using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1scene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2scene");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3scene");
    }
}
