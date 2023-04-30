using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [FormerlySerializedAs("isPitchRotated")] [SerializeField] public bool isPitchInverted = false; 

    private PlayerInput _playerInput;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void ChangeActionMapping(string ActionMapName)
    {
        _playerInput.SwitchCurrentActionMap(ActionMapName);
    }

    public string GetCurrentActionMapping()
    {
        return _playerInput.currentActionMap.name;
    }

    public void SetPlayerInput(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }
    
}
