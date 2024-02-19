using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSwitch : MonoBehaviour
{
    
    public  GameObject liftUI;
    readonly bool _started = false;
    private TopDownCharacterController _player;
    public bool floor2Unlocked;
    public bool floor3Unlocked;
    public bool floor1Unlocked = true;
    public GameObject liftDoorClose1;
    public GameObject liftDoorClose2;
    public GameObject liftDoorOpen1;
    public GameObject liftDoorOpen2;
    public AudioSource liftClosing;
    public AudioSource errorNoise;
    public Image floor2Button;
    public Image floor3Button;
    public Image floor1Button;
    public Animator animator;
    public string triggerName;
    public GameObject fade;

    private void Awake()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
        floor2Unlocked = _player.floor2Unlocked;
        floor3Unlocked = _player.floor3Unlocked;
    }

    private void FixedUpdate()
    {
        floor2Button.color = floor2Unlocked ? Color.green : Color.red;

        floor3Button.color = floor3Unlocked ? Color.green : Color.red;

        if (floor1Unlocked)
        {
            floor1Button.color = Color.green;
        }
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
        SceneManager.LoadScene("Test Scene 2");
    }

    public void Floor2()
    {
        if (_started == false && floor2Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor2(5));
        }
        else if (floor2Unlocked == false)
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
        if (_started == false && floor3Unlocked)
        {
            Destroy(liftUI);
            StartCoroutine(Floor3(5));
        }
        else if (floor3Unlocked == false)
        {
            errorNoise.Play();
        }

    }

    IEnumerator Floor3(float time)
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
