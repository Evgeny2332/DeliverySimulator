using UnityEngine;
using YG;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private Transform cameraPosition;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2.0f;
    private Vector3 velocity;
    public bool isGrounded, isMove;

    [SerializeField] private Joystick joystick;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region Movement
        float moveX = 0;
        float moveY = 0;
        if (YandexGame.EnvironmentData.isDesktop)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        else if (YandexGame.EnvironmentData.isMobile)
        {
            moveX = joystick.Horizontal;
            moveY = joystick.Vertical;
        }

        Vector3 cameraForward = new Vector3(cameraPosition.forward.x, 0, cameraPosition.forward.z).normalized;
        Vector3 cameraRight = new Vector3(cameraPosition.right.x, 0, cameraPosition.right.z).normalized;

        Vector3 moveDirection = (cameraForward * moveY + cameraRight * moveX).normalized;

        if (moveDirection.magnitude > 0.05f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if(isGrounded)
                isMove = true;
            else
                isMove = false;
        }
        else
        {
            isMove = false;
        }
        #endregion

        #region Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
        #endregion

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {   
        if (isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
