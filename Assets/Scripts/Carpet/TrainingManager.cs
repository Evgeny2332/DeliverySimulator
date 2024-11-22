using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainingManager : MonoBehaviour
{
    [SerializeField] private WalletManager walletManager;
    [SerializeField] private Animator animator;
    [SerializeField] private double needEnergy = 1;
    [SerializeField] private Text needEnergyButtonText;
    [SerializeField] private TextMeshProUGUI needEnergyWindowText;
    [SerializeField] private GameObject trainingInterface;

    private void OnEnable() => EventManager.PlayerUsedCarpet.Invoke();
    private void OnDisable() => EventManager.PlayerUnusedCarpet.Invoke();

    private void BuyUpPower()
    {
        walletManager.Energy -= needEnergy;
        needEnergy *= 1.3;
        needEnergyWindowText.text = $"Требуется {NumberFormater.FormatNumber(needEnergy)}";
        needEnergyButtonText.text = $"{NumberFormater.FormatNumber(needEnergy)}";
        walletManager.Power++;
    }

    private IEnumerator Training()
    {
        if (walletManager.Energy >= needEnergy)
        {
            BuyUpPower();
            trainingInterface.SetActive(false);
            animator.Play("Training");
            yield return new WaitForSeconds(1.5f);
            animator.Play("Idle");
            trainingInterface.SetActive(true);
        }
    }
 
    public void StartTraining() => StartCoroutine(Training());
    public void EndTraining() => gameObject.SetActive(false);
} 
