using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject escMenu;
    private bool escOpen;
    public void RestartButton()
    {
        SceneManager.LoadScene("Map");

    }

    public void ExitButton()
    {

        SceneManager.LoadScene("StartScreen");

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScreen");
        
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        escMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escOpen == false)
        {
            Time.timeScale = 0.0f;
            escMenu.SetActive(true);
            escOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escOpen == true)
        {
            Time.timeScale = 1.0f;
            escMenu.SetActive(false);
            escOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
