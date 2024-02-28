using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class MenuManager : MonoBehaviour
{
    // Initialising variables
    public GameObject player;
    public GameObject canvas;
    [FormerlySerializedAs("Upgrades")] public GameObject upgrades;
    public GameObject mPanelSettingsAndControls;
    public GameObject mMainMenu;
    private bool _settingsAndControlsOpen;

    // These functions are pretty self-explanatory 
    
    public void OpenSettingsAndControls()
    {
        if (_settingsAndControlsOpen == false)
        {
            mPanelSettingsAndControls.SetActive(true);
            mMainMenu.SetActive(false);
            _settingsAndControlsOpen = true;
        }
        else
        {
            mPanelSettingsAndControls.SetActive(false);
            mMainMenu.SetActive(true);
            _settingsAndControlsOpen = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartingLevel()
    {  
        SceneManager.LoadScene("StartingHotelLobby");
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(player);
        Destroy(canvas);
        Destroy(upgrades);
        Time.timeScale = 1f;
    }

    public void ReloadLevel() 
    {
        SceneManager.LoadScene("Hotel Lobby Death");
        Destroy(player);
        Destroy(canvas);
        Time.timeScale = 1f;
    }
}
