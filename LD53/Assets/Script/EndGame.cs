using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timePlayedText;
    [SerializeField] private TextMeshProUGUI packagesText;

    public PersistentData data;

    void Start()
    {
        data = FindObjectOfType<PersistentData>();

        timePlayedText.text = "Time Played: " + data.timePlayed;
        packagesText.text = "Packages delivered: " + data.packages;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
