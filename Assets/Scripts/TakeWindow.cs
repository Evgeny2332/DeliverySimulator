using TMPro;
using UnityEngine;
using YG;


public class TakeWindow : MonoBehaviour
{
    [SerializeField] private Transform targetCameraPlayer;
    [SerializeField] private GameObject imageMove;

    [SerializeField] private TextMeshProUGUI textHead;
    [SerializeField] private string desktopText, mobileText;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            textHead.text = desktopText;
        }
        else if(YandexGame.EnvironmentData.isMobile)
        {
            textHead.text = mobileText;
        }
    }

    private void Update()
    {
        transform.LookAt(targetCameraPlayer.transform);
        transform.Rotate(0, 180, 0);
    }
}