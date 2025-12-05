using UnityEngine;
using System.Collections;

public class TutorialStart : MonoBehaviour
{
    [Header("말풍선 (1 → 2 순서로 넣기)")]
    public GameObject bubble1;
    public GameObject bubble2;

    [Header("플레이어 관련")]
    public MonoBehaviour playerMovement;
    public Animator playerAnimator;

    [Header("배경 움직임 스크립트들")]
    public MonoBehaviour[] backgroundMovers;

    [Header("설정")]
    public float firstBubbleTime = 2f;   // 말풍선1만 보이는 시간
    public float bothBubbleTime = 2f;    // 말풍선1+2 같이 보이는 시간

    IEnumerator Start()
    {
        // 시작할 때 말풍선 숨기기
        bubble1.SetActive(false);
        bubble2.SetActive(false);

        // 플레이어 idle 고정
        playerMovement.enabled = false;
        playerAnimator.SetBool("isRunning", false);

        // 배경 이동 OFF
        foreach (var bg in backgroundMovers)
            bg.enabled = false;

        // 1️⃣ 말풍선1만 표시
        bubble1.SetActive(true);
        yield return new WaitForSeconds(firstBubbleTime);

        // 2️⃣ 말풍선1 유지 + 말풍선2 표시
        bubble2.SetActive(true);
        yield return new WaitForSeconds(bothBubbleTime);

        // 3️⃣ 둘 다 OFF
        bubble1.SetActive(false);
        bubble2.SetActive(false);

        // 4️⃣ 플레이어 run 전환
        playerMovement.enabled = true;
        playerAnimator.SetBool("isRunning", true);

        // 5️⃣ 배경 ON
        foreach (var bg in backgroundMovers)
            bg.enabled = true;
    }
}
