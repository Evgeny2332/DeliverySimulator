using UnityEngine;
using UnityEngine.UI;

public class UsePetWindow : MonoBehaviour
{
    public static UsePetWindow Instance;

    [SerializeField] private GameObject windowPet;
    [SerializeField] private Image icon;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void OnWindow(Sprite sprite)
    {
        windowPet.SetActive(true);
        icon.sprite = sprite;
    }
}
