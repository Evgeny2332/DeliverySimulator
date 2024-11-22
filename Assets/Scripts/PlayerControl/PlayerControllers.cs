using UnityEngine;
using YG;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject mobileController;
    [SerializeField] private GameObject playerBody;

    private void OnEnable()
    {
        EventManager.PlayerUsedCarpet += OffControllers;
        EventManager.PlayerUnusedCarpet += OnControllers;
    }
    private void OnDisable()
    {
        EventManager.PlayerUsedCarpet -= OffControllers;
        EventManager.PlayerUnusedCarpet -= OnControllers;
    }

    private void OnControllers()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (YandexGame.EnvironmentData.isMobile)
        {
            mobileController.SetActive(true);
        }
        playerBody.SetActive(true);
        playerCamera.SetActive(true);
    }
    private void OffControllers()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (YandexGame.EnvironmentData.isMobile)
        {
            mobileController.SetActive(false);
        }
        playerBody.SetActive(false);
        playerCamera.SetActive(false);
    }
}
