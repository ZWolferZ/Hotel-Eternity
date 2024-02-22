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

    private void Awake()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
    }

    private void FixedUpdate()
    {
        floor2Button.color = _player.floor2Unlocked ? Color.green : Color.red;

        floor3Button.color = _player.floor3Unlocked ? Color.green : Color.red;

        floor1Button.color = _player.floor1Unlocked ? Color.green : Color.red;

        yourFloor.color = _player.yourFloorUnlocked ? Color.green : Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
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
        if (_started == false && _player.yourFloorUnlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor2(5));
        }
        else if (_player.yourFloorUnlocked == false)
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
        if (_started == false && _player.floor2Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor2(5));
        }
        else if (_player.floor2Unlocked == false)
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
        if (_started == false && _player.floor3Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor3(5));
        }
        else if (_player.floor3Unlocked == false)
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
