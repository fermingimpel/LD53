using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject baseCanvas;

    [SerializeField] private string gameSceneName;


    private void Start()
    {
        InputManager.Instance.ChangeActionMapping("UI");
    }

    public void ToggleOptionsCanvas()
    {
        baseCanvas.SetActive(optionsCanvas.activeSelf);
        optionsCanvas.SetActive(!optionsCanvas.activeSelf);
    }

    public void ToggleTutorialCanvas()
    {
        baseCanvas.SetActive(tutorialCanvas.activeSelf);
        tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
    }

    public void ToggleCreditsCanvas()
    {
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
