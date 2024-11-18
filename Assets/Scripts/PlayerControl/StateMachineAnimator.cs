using UnityEngine;

public class StateMachineAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Animator animator;

    private void Update()
    {
        Debug.Log(playerMovement.isMove);
        if (playerMovement.isMove)
            animator.SetBool("isRun", true);
        else
            animator.SetBool("isRun", false);


        if (!playerMovement.isGrounded)
            animator.SetBool("isFall", true);
        else
            animator.SetBool("isFall", false);
    }
}
