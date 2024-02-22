using UnityEngine;


public class PopupTrigger : MonoBehaviour
{
   
    [SerializeField ]private GameObject uiPopUp;
    private TopDownCharacterController _player;
    
    private void Awake()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || _player.tutorialtrigger) return;
        Time.timeScale = 0;
        uiPopUp.SetActive(true);
        _player.tutorialtrigger = true;
        _player.paused = true;

    }

    public void Continue()
    {
        Time.timeScale = 1;
        uiPopUp.SetActive(false);
        _player.paused = false;
    }
}
