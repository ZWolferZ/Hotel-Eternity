using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSwitch : MonoBehaviour
{
    
    public  GameObject liftUI;
    readonly bool _started = false;
    private TopDownCharacterController _player;
    public GameObject liftDoorClose1;
    public GameObject liftDoorClose2;
    public GameObject liftDoorOpen1;
    public GameObject liftDoorOpen2;
    public AudioSource liftClosing;
    public AudioSource liftOpening;
    public AudioSource errorNoise;
    public Image floor2Button;
    public Image floor3Button;
    public Image floor1Button;
    public Image yourFloor;
    public Animator animator;
    public string triggerName;
    public GameObject fade;
    private Upgrades _upgrades;
    private LiftValid _liftValid;
    

    private void Awake()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
        _upgrades = FindObjectOfType<Upgrades>();
        _liftValid = FindObjectOfType<LiftValid>();
    }

    private void FixedUpdate()
    {
        floor2Button.color = _upgrades.floor2Unlocked ? Color.green : Color.red;

        floor3Button.color = _upgrades.floor3Unlocked ? Color.green : Color.red;

        floor1Button.color = _upgrades.floor1Unlocked ? Color.green : Color.red;

        yourFloor.color = _upgrades.yourFloorUnlocked ? Color.green : Color.red;

        if (_liftValid._steppedOut)
        {
            _player.returning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") &&  _player.returning == false)
        {

            liftUI.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            liftUI.SetActive(false);

        }
    }

    public void Floor1()
    {
        if (_started) return;
        Destroy(liftUI);
        StartCoroutine(Floor1(5));

    }

    private IEnumerator Floor1(float time)
    {
        liftDoorOpen1.SetActive(false);
        liftDoorOpen2.SetActive(false);
        liftDoorClose1.SetActive(true);
        liftDoorClose2.SetActive(true);
        fade.SetActive(true);
        liftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Floor 1");
    }
    public void YourFloorButton()
    {
        if (_started == false && _upgrades.yourFloorUnlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor2(5));
        }
        else if (_upgrades.yourFloorUnlocked == false)
        {
            errorNoise.Play();
        }
    }

    private IEnumerator YourFloorEnumerator(float time)
    {
        liftDoorOpen1.SetActive(false);
        liftDoorOpen2.SetActive(false);
        liftDoorClose1.SetActive(true);
        liftDoorClose2.SetActive(true);
        fade.SetActive(true);
        liftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YourFloor");
    }
    public void Floor2()
    {
        if (_started == false && _upgrades.floor2Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor2(5));
        }
        else if (_upgrades.floor2Unlocked == false)
        {
            errorNoise.Play();
        }

    }

    private IEnumerator Floor2(float time)
    {
        liftDoorOpen1.SetActive(false);
        liftDoorOpen2.SetActive(false);
        liftDoorClose1.SetActive(true);
        liftDoorClose2.SetActive(true);
        fade.SetActive(true);
        liftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Floor 2");
    }

    public void Floor3()
    {
        if (_started == false && _upgrades.floor3Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor3(5));
        }
        else if (_upgrades.floor3Unlocked == false)
        {
            errorNoise.Play();
        }

    }

    private IEnumerator Floor3(float time)
    {
        liftDoorOpen1.SetActive(false);
        liftDoorOpen2.SetActive(false);
        liftDoorClose1.SetActive(true);
        liftDoorClose2.SetActive(true);
        fade.SetActive(true);
        liftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Floor 3");
    }

    
}
