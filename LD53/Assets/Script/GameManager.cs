using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float playTime = 75.0f;
    [SerializeField] private string menuSceneName = "jorge";
    private bool playing = true;

    private float maxTimePlayed = 0.0f;
    private PlayerHUD playerHUD;
    
    void Start()
    {
        playerHUD = FindObjectOfType<PlayerHUD>();
        playerHUD.SetTimerTextValue((int)playTime);
    }

    void Update()
    {
        if (!playing)
            return;

        playTime -= Time.deltaTime;
        maxTimePlayed += Time.deltaTime;

        if(playTime < 0.0f)
        {
            playTime = 0.0f;
            playing = false;

            PersistentData data = FindObjectOfType<PersistentData>();
            data.timePlayed = (int)maxTimePlayed;
            ShipPackageController spc = FindObjectOfType<ShipPackageController>();
            data.packages = spc.GetPackagesDelivered();

            LoadScene(menuSceneName);
        }

        playerHUD.SetTimerTextValue((int)playTime);
    }

    public void AddTimeRemaining(float Value)
    {
        playTime += Value;
        playerHUD.SetTimerTextValue((int)playTime);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
