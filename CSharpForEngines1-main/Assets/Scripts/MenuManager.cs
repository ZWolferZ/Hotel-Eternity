using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject m_Panel_SettingsAndControls;
    public GameObject m_MainMenu;
    bool SettingsAndControlsOpen = false;

    public void OpenSettingsAndControls()
    {
        if (SettingsAndControlsOpen == false)
        {
            m_Panel_SettingsAndControls.SetActive(true);
            m_MainMenu.SetActive(false);
            SettingsAndControlsOpen = true;
        }
        else
        {
            m_Panel_SettingsAndControls.SetActive(false);
            m_MainMenu.SetActive(true);
            SettingsAndControlsOpen = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartingLevel()
    {
           SceneManager.LoadScene("Starting Level");
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void ReloadLevel() 
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
