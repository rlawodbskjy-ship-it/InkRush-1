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
    public BackgroundMove backgroundMove;      // ✅ 배경 이동
    public PlayerController playerController;  // ✅ 플레이어 제어

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(GoalFlow());
        }
    }

    IEnumerator GoalFlow()
    {
        // 🛑 0️⃣ 게임 전체 멈춤
        if (backgroundMove != null)
            backgroundMove.isMoving = false;

        if (playerController != null)
            playerController.StopRunning();

        // 1️⃣ 폭죽
        firework.SetActive(true);
        yield return new WaitForSeconds(2f);

        // 2️⃣ 엔딩 패널
        endingPanel.SetActive(true);
        endingSequence.PlayEnding();

        yield return new WaitForSeconds(3.5f);

        // 3️⃣ 엔딩 패널 제거
        endingPanel.SetActive(false);

        // 4️⃣ 미션 클리어 화면
        missionClearPanel.SetActive(true);
    }
}
