using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ControlsSettings : MonoBehaviour
{
    [SerializeField] private Toggle InvertPitchToggle;

    private void Start()
    {
        InvertPitchToggle.SetIsOnWithoutNotify(InputManager.Instance.isPitchInverted);
        InvertPitchToggle.onValueChanged.AddListener((value) => OnToggleValueChanged(value));
    }

    public void OnToggleValueChanged(bool value)
    {
        InputManager.Instance.isPitchInverted = value;
    }

    private void OnDestroy()
    {
        InvertPitchToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
}
