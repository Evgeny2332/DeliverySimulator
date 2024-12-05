using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenPet : MonoBehaviour
{
    [SerializeField] private Image pet;
    [SerializeField] private Sprite[] petsIcons;

    [SerializeField] private Animator animtator;

    public int petId;

    private void OnEnable()
    {
        pet.sprite = petsIcons[petId];
        animtator.Play("NotAnim");
        animtator.Play("OpenPetAnim");
        StartCoroutine(timerToHideWindow());
    }

    private IEnumerator timerToHideWindow()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
