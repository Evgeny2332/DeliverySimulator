using UnityEngine;
using UnityEngine.UI;

public class SpawnerPets : MonoBehaviour
{
    [SerializeField] private PetsInventory petsInventory;
    [SerializeField] private WalletManager walletManager;

    [SerializeField] private GameObject petsWindow;
    [SerializeField] private GameObject[] pets;
    [SerializeField] private int priceOpenPet;
    [SerializeField] private Text priceOpenPetText;

    private bool isUse = false;

    [SerializeField] private GameObject openPetWindow;
    [SerializeField] private OpenPet openPet;

    private void Start()
    {
        priceOpenPetText.text = priceOpenPet.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUse)
        {
            petsWindow.SetActive(true);
            EventManager.PlayerUsedCarpet.Invoke();
            isUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isUse)
        {
            isUse = false;
        }
    }

    public void BuyPet()
    {
        if (walletManager.Energy >= priceOpenPet && petsInventory.GetCoundPet() < 15)
        {
            walletManager.Energy -= priceOpenPet;
            int valuePet = Random.Range(0, 101);
            if (valuePet >= 0 && valuePet <= 35)
            {
                openPet.petId = 0;
                petsInventory.AddPet(pets[0]);
            }
            else if (valuePet >= 36 && valuePet <= 60)
            {
                openPet.petId = 1;
                petsInventory.AddPet(pets[1]);
            }
            else if (valuePet >= 61 && valuePet <= 80)
            {
                openPet.petId = 2;
                petsInventory.AddPet(pets[2]);
            }
            else if (valuePet >= 81 && valuePet <= 95)
            {
                openPet.petId = 3;
                petsInventory.AddPet(pets[3]);
            }
            else if (valuePet >= 96 && valuePet <= 100)
            {
                openPet.petId = 4;
                petsInventory.AddPet(pets[4]);
            }
            openPetWindow.SetActive(true);
        }
    }

    public void ClosePetsWindow()
    {
        petsWindow?.SetActive(false);
        EventManager.PlayerUnusedCarpet.Invoke();
    }
}
