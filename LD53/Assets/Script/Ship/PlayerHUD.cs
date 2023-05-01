using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI packagesRemainingText;
    [SerializeField] private Image powerImageSlider;

    [SerializeField] Color powerNotReadyColor;
    [SerializeField] Color powerReadyColor;

    public void SetTimerTextValue(float remainingTime)
    {
        timerText.text = remainingTime.ToString();
    }

    public void SetPackagesRemaining(int packagesRemaining)
    {
        packagesRemainingText.text = packagesRemaining.ToString();
    }

    public void SetPowerImageValue(float powerValue, float minPowerToThrow)
    {
        powerImageSlider.fillAmount = powerValue;
        if (powerValue >= minPowerToThrow)
            powerImageSlider.color = powerReadyColor;
        else
            powerImageSlider.color = powerNotReadyColor;
    }

}
