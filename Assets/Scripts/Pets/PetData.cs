using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPet", menuName = "Game/Pet Data")]
public class PetData : ScriptableObject
{
    public string petName;
    public GameObject petObject;
    public Sprite petIcon;
    public float boostValue;
}
