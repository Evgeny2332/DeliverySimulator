using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class PetsInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> petSlots;
    [SerializeField] private Transform parentInventory;

    [SerializeField] private int countPets;
    [SerializeField] private Text countPetsText;

    public static Action TakenPet;

    private void AddPetToInventory()
    {
        Instantiate(petSlots[countPets - 1], parentInventory);
    }

    public void AddPet(GameObject pet)
    {
        petSlots.Add(pet);
        countPets++;
        countPetsText.text = $"{countPets}/15";
        AddPetToInventory();
    }

    public void DeletePet()
    {
        for (int i = 0; i < petSlots.Count; i++)
        {
            if (petSlots[i] == null)
            {
                petSlots.RemoveAt(i);
            }
        }
        countPets--;
        countPetsText.text = $"{countPets}/15";
    }

    public int GetCoundPet()
    {
        return countPets;
    }
}
