using UnityEngine;
using UnityEngine.UI;

public class PetSlot : MonoBehaviour
{
    [SerializeField] private int petId;

    [SerializeField] private Image icon;
    [SerializeField] private Sprite iconSpite;

    [SerializeField] private float boostValue;
    [SerializeField] private Text boost;

    [SerializeField] private GameObject spriteTake;

    private void OnEnable()
    {
        PetsInventory.TakenPet += OffTakePet;
    }

    private void OnDisable()
    {
        PetsInventory.TakenPet -= OffTakePet;
    }

    private void Start()
    {
        icon.sprite = iconSpite;
        boost.text = $"X{boostValue}";  
    }

    private void OffTakePet()
    {
        spriteTake.SetActive(false);
        Pet.Instance.isTake = false;
    }

    public void TakePet()
    {
        if (spriteTake.activeSelf == false)
        {
            PetsInventory.TakenPet.Invoke();
            spriteTake.SetActive(true);
            Pet.Instance.SetPet(petId);
            Pet.Instance.mulptiplierPet = boostValue;
        }
        else
        {
            Pet.Instance.isTake = false;
            spriteTake.SetActive(false);
            Pet.Instance.DiactivePet();
        }
    }
}
