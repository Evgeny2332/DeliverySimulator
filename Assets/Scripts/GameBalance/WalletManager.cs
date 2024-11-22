using UnityEngine;
using UnityEngine.UI;

public class WalletManager : MonoBehaviour
{
    private double power = 1;
    private double energy = 1;

    [SerializeField] private Text powerText;
    [SerializeField] private Text energyText;

    public double Power
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
            UpdateTextPower();
        }
    }
    public double Energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = value;
            UpdateTextEnergy();
        }
    }

    private void UpdateTextPower() => powerText.text = NumberFormater.FormatNumber(power);
    private void UpdateTextEnergy() => energyText.text = NumberFormater.FormatNumber(energy);

    private void Start()
    {
        UpdateTextPower();
        UpdateTextEnergy();
    }
}
