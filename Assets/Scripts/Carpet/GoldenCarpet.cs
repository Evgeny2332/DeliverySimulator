using UnityEngine;
using UnityEngine.UI;
using YG;

public class GoldenCarpet : Carpet
{
    [SerializeField] private TrainingManager trainingManager;
    [SerializeField] private WalletManager walletManager;
    private double tempNeedEnergy;

    [SerializeField] private GameObject convertWindow;
    [SerializeField] private Text convertText;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Reward;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Reward;
    }
    private void Reward(int id)
    {
        if (id == 1)
        {
            walletManager.Power += CalculatorConvert(walletManager.Energy);
            walletManager.Energy = 0;
            trainingManager.NeedEnergy = tempNeedEnergy;

            CloseConvertWindow();
        }
    }

    private int CalculatorConvert(double energy)
    {
        double tempNeedEnergy = trainingManager.NeedEnergy;
        double tempEnergy = energy;
        int countPower = 0;
        while (tempNeedEnergy <= tempEnergy)
        {
            tempNeedEnergy *= 1.3;
            tempEnergy -= tempNeedEnergy;
            countPower++;
        }
        this.tempNeedEnergy = tempNeedEnergy;
        return countPower;
    }

    public override void TriggerStay()
    {
        takeWindow.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenConvertWindow();
        }
    }

    public override void TriggerExit()
    {
        takeWindow.SetActive(false);
    }

    public void OpenConvertWindow()
    {
        convertText.text = $"Вы желаете обменять {walletManager.Energy} энергии на {CalculatorConvert(walletManager.Energy)} силы за рекламу?";
        EventManager.PlayerUsedCarpet();
        convertWindow.SetActive(true);
    }

    public void CloseConvertWindow()
    {
        convertWindow.SetActive(false);
        EventManager.PlayerUnusedCarpet();
    }
}
