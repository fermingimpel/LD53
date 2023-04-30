using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject VideoSettingsPanel;
    [SerializeField] private GameObject GraphicsSettingsPanel;
    [SerializeField] private GameObject AudioSettingsPanel;
    [SerializeField] private GameObject ControlsSettingsPanel;
    
    [Header("UI Functionality")]
    [SerializeField] private EventSystem Eventsystem;
    [SerializeField] private GameObject FirstSelectedGameObject;
    [SerializeField] private GameObject FirstVideoSettingsGameObject;
    [SerializeField] private GameObject FirstControlsSettingsGameObject;
    [SerializeField] private GameObject FirstGraphicsSettingsGameObject;
    [SerializeField] private GameObject FirstAudioSettingsGameObject;

    private List<GameObject> Panels = new List<GameObject>();

    private void Start()
    {
        Panels.Add(VideoSettingsPanel);
        Panels.Add(GraphicsSettingsPanel);
        Panels.Add(AudioSettingsPanel);
        Panels.Add(ControlsSettingsPanel);
    }

    private void OnEnable()
    {
        Eventsystem.SetSelectedGameObject(FirstSelectedGameObject);
    }

    public void OpenVideoSettings()
    {
        EnablePanel(VideoSettingsPanel);
        Eventsystem.SetSelectedGameObject(FirstVideoSettingsGameObject);
    }

    public void OpenGraphicsSettings()
    {
        EnablePanel(GraphicsSettingsPanel);
        Eventsystem.SetSelectedGameObject(FirstGraphicsSettingsGameObject);
    }

    public void OpenAudioSettins()
    {
        EnablePanel(AudioSettingsPanel);
        Eventsystem.SetSelectedGameObject(FirstAudioSettingsGameObject);
    }

    public void OpenControlsSettings()
    {
        EnablePanel(ControlsSettingsPanel);
        Eventsystem.SetSelectedGameObject(FirstControlsSettingsGameObject);
    }

    void EnablePanel(GameObject Panel)
    {
        foreach (GameObject panel in Panels)
        {
            if (panel == Panel)
            {
                panel.SetActive(true);
                continue;
            }
            panel.SetActive(false);
        }
    }

    void DisablePanels(GameObject Panel)
    {
        foreach (GameObject panel in Panels)
        {
            if (panel == Panel)
            {
                panel.SetActive(false); 
            }
        }
    }
}
