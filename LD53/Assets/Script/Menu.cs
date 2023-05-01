using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject tutorialCanvas;

    [SerializeField] private string gameSceneName;


    public void ToggleOptionsCanvas()
    {
        optionsCanvas.SetActive(!optionsCanvas.activeSelf);
    }

    public void ToggleCreditsCanvas()
    {
        creditsCanvas.SetActive(!creditsCanvas.activeSelf);
    }

    public void ToggleTutorialCanvas()
    {
        tutorialCanvas.SetActive(!tutorialCanvas.activeSelf);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
