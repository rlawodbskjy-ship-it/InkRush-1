using UnityEngine;
using System.Collections;

public class TutorialStart : MonoBehaviour
{
    [Header("말풍선 (1 → 2 순서로 넣기)")]
    public GameObject bubble1;
    public GameObject bubble2;

    [Header("플레이어")]
    public PlayerController playerController;   // ✅ MonoBehaviour 말고 실제 스크립트
    public Animator playerAnimator;

    [Header("배경 움직임 스크립트들")]
    public BackgroundMove[] backgroundMovers;

    [Header("시간 설정")]
    public float firstBubbleTime = 2f;
    public float bothBubbleTime = 2f;

    IEnumerator Start()
    {
        // ✅ 말풍선 초기 OFF
        bubble1.SetActive(false);
        bubble2.SetActive(false);

        // ✅ 플레이어 완전 정지
        playerController.canRun = false;
        playerAnimator.SetBool("isRunning", false);

        // ✅ 배경 이동 정지
        foreach (var bg in backgroundMovers)
            bg.isMoving = false;

        // 1️⃣ 말풍선 1
        bubble1.SetActive(true);
        yield return new WaitForSeconds(firstBubbleTime);

        // 2️⃣ 말풍선 1 + 2
        bubble2.SetActive(true);
        yield return new WaitForSeconds(bothBubbleTime);

        // 3️⃣ 말풍선 제거
        bubble1.SetActive(false);
        bubble2.SetActive(false);

        // ✅ 게임 시작
        playerController.canRun = true;
        playerAnimator.SetBool("isRunning", true);

        foreach (var bg in backgroundMovers)
            bg.isMoving = true;
    }
}
