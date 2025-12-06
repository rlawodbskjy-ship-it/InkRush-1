using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public bool canRun = false;   // ✅ 처음엔 false !!

    void Update()
    {
        if (!canRun)
        {
            anim.SetBool("isRunning", false);
            return;
        }

        anim.SetBool("isRunning", true);
    }

    public void StartRunning()
    {
        canRun = true;
        anim.SetBool("isRunning", true);
    }

    public void StopRunning()
    {
        canRun = false;
        anim.SetBool("isRunning", false);
    }
}
