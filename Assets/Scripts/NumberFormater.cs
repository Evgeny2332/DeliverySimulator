using System;
using UnityEngine;

public class NumberFormater : MonoBehaviour
{
    public static string FormatNumber(double number)
    {
        if (number >= 1_000_000_000)
            return (number / 1_000_000_000).ToString("0.##") + "B";
        else if (number >= 1_000_000)
            return (number / 1_000_000).ToString("0.##") + "M";
        else if (number >= 1_000)
            return (number / 1_000).ToString("0.##") + "K";
        else
            return Math.Round(number, 2).ToString();
    }
}
