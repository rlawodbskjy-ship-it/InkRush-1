using UnityEngine;

public class StoryStartButton : MonoBehaviour
{
    public string nextLevelSceneName;   // Inspector에서 지정

    public void OnClickStart()
    {
        FadeController fader = FindObjectOfType<FadeController>();

        if (fader == null)
        {
            Debug.LogError("FadeController를 찾을 수 없음");
            return;
        }

        fader.FadeToScene(nextLevelSceneName);
    }
}
