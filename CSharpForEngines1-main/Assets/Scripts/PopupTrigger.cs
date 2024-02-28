using UnityEngine;


public class PopupTrigger : MonoBehaviour
{
    // Initialising variables
    [SerializeField ]private GameObject uiPopUp;
    private TopDownCharacterController _player;
    private Upgrades _upgrades;
    
        // Yoink Scripts
    private void Awake()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
        _upgrades = FindObjectOfType<Upgrades>();
    }

    // On trigger, pause the game and show the guide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || _upgrades.tutorialtrigger) return;
        Time.timeScale = 0;
        uiPopUp.SetActive(true);
        _upgrades.tutorialtrigger = true;
        _player.paused = true;

    }

    public void Continue()
    {
        Time.timeScale = 1;
        uiPopUp.SetActive(false);
        _player.paused = false;
    }
}
