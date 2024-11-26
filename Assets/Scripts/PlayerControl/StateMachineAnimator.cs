using UnityEngine;

public class StateMachineAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractive playerInteractive;

    private Animator animator;

    // Переменные для логики
    private bool isMove;
    private bool isTakeBox;
    private bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Пример получения значений (замените на свою логику)
        isMove = playerMovement.isMove; // Персонаж движется
        isTakeBox = playerInteractive.isTakeBox;       // Удерживание коробки
        isGrounded = playerMovement.isGrounded; // Проверка на землю

        // Передача значений в аниматор
        animator.SetBool("isMove", isMove);
        animator.SetBool("isTakeBox", isTakeBox);
        animator.SetBool("isGrounded", isGrounded);
    }
}
