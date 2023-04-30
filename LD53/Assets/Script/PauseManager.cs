using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
   [SerializeField] GameObject PauseScreen;
   [SerializeField] GameObject OptionsScreen;
   private EventSystem eventsystem;
   [SerializeField] private GameObject FirstSelectedGameObject;

   private void Start()
   {
      eventsystem = EventSystem.current;
   }

   public void OnResume()
   {
      Time.timeScale = 1;
      PauseScreen.SetActive(false);
      OptionsScreen.SetActive(false);
      InputManager.Instance.ChangeActionMapping("Player");
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      //todo: add animations later
   }

   public void OnPause()
   {
      if (InputManager.Instance.GetCurrentActionMapping() == "Player")
      {
         eventsystem.SetSelectedGameObject(FirstSelectedGameObject);
         Time.timeScale = 0;
         PauseScreen.SetActive(true);
         InputManager.Instance.ChangeActionMapping("UI");
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
      }
      else
      {
         OnResume();
      }
      //todo: add animations later
   }

   public void OnRestart()
   {
      //todo: replace with game scene
      SceneManager.LoadScene("Iker");
   }

   public void OnQuit()
   {
      //todo: Replace with menu
      SceneManager.LoadScene("Iker");
   }

   public void OnOptionsOpen()
   {
      //todo: change to animations later
      OptionsScreen.SetActive(true);
      PauseScreen.SetActive(false);
   }

   public void OnOptionsExit()
   {
      //todo: change to animations later
      eventsystem.SetSelectedGameObject(FirstSelectedGameObject);
      PauseScreen.SetActive(true);
      OptionsScreen.SetActive(false);
   }
   
}
