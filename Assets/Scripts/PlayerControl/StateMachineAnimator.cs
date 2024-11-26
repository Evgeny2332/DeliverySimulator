using UnityEngine;

public class StateMachineAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractive playerInteractive;

    private Animator animator;

    // ���������� ��� ������
    private bool isMove;
    private bool isTakeBox;
    private bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ������ ��������� �������� (�������� �� ���� ������)
        isMove = playerMovement.isMove; // �������� ��������
        isTakeBox = playerInteractive.isTakeBox;       // ����������� �������
        isGrounded = playerMovement.isGrounded; // �������� �� �����

        // �������� �������� � ��������
        animator.SetBool("isMove", isMove);
        animator.SetBool("isTakeBox", isTakeBox);
        animator.SetBool("isGrounded", isGrounded);
    }
}
