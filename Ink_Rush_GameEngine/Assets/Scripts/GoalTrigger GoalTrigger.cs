using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    [Header("연출 오브젝트")]
    public GameObject firework;
    public GameObject endingPanel;
    public GameObject missionClearPanel;

    [Header("스크립트 참조")]
    public EndingSequence endingSequence;
    public BackgroundMove backgroundMove;
    public PlayerController playerController;

    [Header("오디오")]
    public AudioSource bgmSource;      
    public AudioSource clearBgmSource; 

    private bool triggered = false;

    // 🔥 모든 스크립트가 확인 가능!
    public static bool MissionCleared = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            MissionCleared = true;   // ✅ 미션 클리어!
            StartCoroutine(GoalFlow());
        }
    }

    IEnumerator GoalFlow()
    {
        if (backgroundMove != null) backgroundMove.isMoving = false;
        if (playerController != null) playerController.StopRunning();

        if (bgmSource != null) bgmSource.Stop();
        if (clearBgmSource != null) clearBgmSource.Play();

        firework.SetActive(true);
        yield return new WaitForSeconds(2f);

        endingPanel.SetActive(true);
        endingSequence.PlayEnding();
        yield return new WaitForSeconds(3.5f);

        endingPanel.SetActive(false);
        missionClearPanel.SetActive(true);
    }
}
