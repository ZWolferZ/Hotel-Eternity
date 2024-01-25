using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject m_Panel_SettingsAndControls;
    bool SettingsAndControlsOpen = false;

    public void OpenSettingsAndControls()
    {
        if (SettingsAndControlsOpen == false)
        {
            m_Panel_SettingsAndControls.SetActive(true);
            SettingsAndControlsOpen = true;
        }
        else
        {
            m_Panel_SettingsAndControls.SetActive(false);
            SettingsAndControlsOpen = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel1()
    {
           SceneManager.LoadScene("Starting Level");
    }
}
