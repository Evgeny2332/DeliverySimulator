using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class CameraController : MonoBehaviour
{
    private bool isCursorVisable = false;

    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private TouchController touchController;

    [SerializeField] private GameObject mobileControllersCanvas;
    [SerializeField] private float rotationSpeedX, rotationSpeedY;

    [SerializeField] private float horizontalSpeed, verticalSpeed;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mobileControllersCanvas.SetActive(false); 
        }
        else
        {
            mobileControllersCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isCursorVisable = !isCursorVisable;
                Cursor.lockState = isCursorVisable ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = isCursorVisable;
            }

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            freeLookCamera.m_XAxis.Value += mouseX * horizontalSpeed * Time.deltaTime;
            freeLookCamera.m_YAxis.Value -= mouseY * verticalSpeed * Time.deltaTime;
        }
        else if (YandexGame.EnvironmentData.isMobile)
        {
            if (touchController.IsDragging())
            {
                Vector2 delta = touchController.dragDelta;

                // Вращаем камеру, только если дельта не равна нулю
                if (delta != Vector2.zero)
                {
                    freeLookCamera.m_XAxis.Value += delta.x * rotationSpeedX * Time.deltaTime;
                    freeLookCamera.m_YAxis.Value -= delta.y * rotationSpeedY * Time.deltaTime;
                }
            }
        }
    }
}
