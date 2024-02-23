using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LiftReturn : MonoBehaviour
{
    private LiftValid _liftValid;
    [SerializeField] private GameObject liftUI;
    [SerializeField] private GameObject liftDoorOpen1; 
    [SerializeField] private GameObject liftDoorOpen2;
    [SerializeField] private  GameObject liftDoorClose1;
    [SerializeField] private GameObject liftDoorClose2;
    [SerializeField] private  GameObject fade;
    [SerializeField] private  AudioSource liftClosing;
    [SerializeField] private string triggerName;
    [SerializeField] private Animator animator;
    private TopDownCharacterController _player;
    
    private void Start()
    {
        _player = FindObjectOfType<TopDownCharacterController>();
        _liftValid = FindObjectOfType<LiftValid>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _liftValid.steppedOut)
        {
            _player.nofire = true;
            liftUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _liftValid.steppedOut)
        {
            _player.nofire = false;
            liftUI.SetActive(false);
        }
    }
    
    public void LobbyButton()
    {
            Destroy(liftUI);
            StartCoroutine(Return(5));
    }
    
    private IEnumerator Return(float time)
    {
        liftDoorOpen1.SetActive(false);
        liftDoorOpen2.SetActive(false);
        liftDoorClose1.SetActive(true);
        liftDoorClose2.SetActive(true);
        fade.SetActive(true);
        animator.SetTrigger(triggerName);
        liftClosing.Play();
        _player.returning = true;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Hotel Lobby");
    }
    
}
