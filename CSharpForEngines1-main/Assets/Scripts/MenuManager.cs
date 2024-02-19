using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject mPanelSettingsAndControls;
    public GameObject mMainMenu;
    private bool _settingsAndControlsOpen;

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
        Time.timeScale = 1f;
    }

    public void ReloadLevel() 
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(player);
        Destroy(canvas);
        Time.timeScale = 1f;
    }
}
