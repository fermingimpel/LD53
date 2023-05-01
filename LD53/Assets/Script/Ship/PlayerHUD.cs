using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI packagesRemainingText;
    [SerializeField] private TextMeshProUGUI packageDeliveredText;
    [SerializeField] private Image powerImageSlider;
    [SerializeField] private GameObject powerBar; 

    [SerializeField] Color powerNotReadyColor;
    [SerializeField] Color powerReadyColor;

    public void SetTimerTextValue(int remainingTime)
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

    public void SetPowerBarEnabled(bool Value)
    {
        powerBar.SetActive(Value);
    }

    public void SetPackageDelivered(int packageDelivered, int maxPackage)
    {
        packageDeliveredText.text = packageDelivered + " / " + maxPackage;
    }

}
