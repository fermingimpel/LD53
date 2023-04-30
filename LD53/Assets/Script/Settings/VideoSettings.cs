using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private Toggle VSyncToggle;
    [FormerlySerializedAs("FullscreenToggle")] [SerializeField] private Toggle fullscreenToggle;
    [FormerlySerializedAs("ResolutionsDropdown")] [SerializeField] private TMP_Dropdown resolutionsDropdown;
    [SerializeField] private TMP_Dropdown graphicsDropdown;

    private Resolution[] resolutions;

    private void Start()
    {
        VSyncToggle.onValueChanged.AddListener((value) => OnVSyncToggle(value));
        fullscreenToggle.onValueChanged.AddListener((value) => SetFullscreen(value));
        VSyncToggle.SetIsOnWithoutNotify(Convert.ToBoolean(QualitySettings.vSyncCount));
        fullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);

        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        List<string> resolutionStrings = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionStrings.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionsDropdown.AddOptions(resolutionStrings);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();
    }

    public void OnVSyncToggle(bool value)
    {
        QualitySettings.vSyncCount = Convert.ToInt32(value);
    }
    
    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;
    }

    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void OnDestroy()
    {
        VSyncToggle.onValueChanged.RemoveListener(OnVSyncToggle);
        fullscreenToggle.onValueChanged.RemoveListener(SetFullscreen);
    }
}
