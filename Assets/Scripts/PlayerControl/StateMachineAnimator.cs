using UnityEngine;

public class StateMachineAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractive playerInteractive;

    [SerializeField] private Animator animator;

    private void Update()
    {
        if (playerMovement.isMove)
        {
            if (playerInteractive.isTakeBox)
            {
                animator.SetBool("isRun2", true);
                animator.SetBool("isRun", false);
                animator.SetBool("isIdleBox", false);
            }
            else
            {
                animator.SetBool("isRun2", false);
                animator.SetBool("isRun", true);
            }
        }
        else
        {
            if (playerInteractive.isTakeBox)
            {
                animator.SetBool("isRun2", false);
                animator.SetBool("isIdleBox", true);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isIdleBox", false);
                animator.SetBool("isRun2", false);
            }
        }


        if (!playerMovement.isGrounded && !playerInteractive.isTakeBox)
        {
            animator.SetBool("isFall", true);
        }
        else if (playerMovement.isGrounded && !playerInteractive.isTakeBox)
        {
            animator.SetBool("isFall", false);
        }
    }
}
