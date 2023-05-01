using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timePlayedText;
    [SerializeField] private TextMeshProUGUI packagesText;

    [SerializeField] string menuSceneName;
    [SerializeField] string gameplaySceneName;


    public PersistentData data;

    void Start()
    {
        data = FindObjectOfType<PersistentData>();

        timePlayedText.text = "Time Played: " + data.timePlayed;
        packagesText.text = "Satisfactory deliveries: " + data.packages;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Replay()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
