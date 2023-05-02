using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject baseCanvas;
    [SerializeField] private GameObject menuFirstSelection;
    [SerializeField] private GameObject CreditsSelection;
    [SerializeField] private GameObject HowToPlay;


    [SerializeField] private string gameSceneName;


    private void Start()
    {
        InputManager.Instance.ChangeActionMapping("UI");
        EventSystem.current.SetSelectedGameObject(menuFirstSelection);
    }

    public void ToggleOptionsCanvas()
    {
        if(baseCanvas.activeSelf)
            EventSystem.current.SetSelectedGameObject(menuFirstSelection);
        baseCanvas.SetActive(optionsCanvas.activeSelf);
        optionsCanvas.SetActive(!optionsCanvas.activeSelf);
    }

    public void ToggleTutorialCanvas()
    {
        if(baseCanvas.activeSelf)
            EventSystem.current.SetSelectedGameObject(menuFirstSelection);
        else
            EventSystem.current.SetSelectedGameObject(HowToPlay);
        baseCanvas.SetActive(tutorialCanvas.activeSelf);
        tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
    }

    public void ToggleCreditsCanvas()
    {
        if(baseCanvas.activeSelf)
            EventSystem.current.SetSelectedGameObject(menuFirstSelection);
        else
            EventSystem.current.SetSelectedGameObject(CreditsSelection);
        baseCanvas.SetActive(creditsCanvas.activeSelf);
        creditsCanvas.SetActive(!creditsCanvas.activeSelf);
    }

    public void LoadGame()
    {
        InputManager.Instance.ChangeActionMapping("Player");
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
