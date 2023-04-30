using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class ControlsSettings : MonoBehaviour
{
    [SerializeField] private string rebindingTextString = "...";

    private TextMeshProUGUI _text;

    private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;
    
    public void RemapButtonClicked(TextMeshProUGUI text)
    {
        _text = text;
        text.text = rebindingTextString;
        // _rebindingOperation = actionToRebind.PerformInteractiveRebinding().WithControlsExcluding("Mouse").OnMatchWaitForAnother(0.1f).OnComplete(operation => RebindComplete()).Start();
    }

    void RebindComplete()
    {
        _text = null;
        _rebindingOperation.Dispose();
    }
    
}
