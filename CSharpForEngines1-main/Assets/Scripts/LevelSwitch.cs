using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Audio;
using UnityEngine.UI;
using UnityEngine.Animations;

public class LevelSwitch : MonoBehaviour
{
    
  public  GameObject LiftUI;
    bool started = false;
    private TopDownCharacterController Player;
    public bool Floor2Unlocked = false;
    public bool Floor3Unlocked = false;
    public bool Floor1Unlocked = true;
    public GameObject LiftDoorClose1;
   public GameObject LiftDoorClose2;
   public GameObject LiftDoorOpen1;
   public GameObject LiftDoorOpen2;
    public AudioSource LiftClosing;
    public AudioSource ErrorNoise;
    public Image Floor2Button;
    public Image Floor3Button;
    public Image Floor1Button;
    public Animator animator;
    public string triggerName;
    public GameObject Fade;

    private void Awake()
    {
        Player = FindAnyObjectByType<TopDownCharacterController>();
        Floor2Unlocked = Player.Floor2Unlocked;
        Floor3Unlocked = Player.Floor3Unlocked;
    }

    private void FixedUpdate()
    {
        if (Floor2Unlocked == true)
        {
            Floor2Button.color = Color.green;
        }
        else
        {
            Floor2Button.color = Color.red;
        }

        if (Floor3Unlocked == true)
        {
            Floor3Button.color = Color.green;
        }
        else
        {
            Floor3Button.color = Color.red;
        }

        if (Floor1Unlocked == true)
        {
            Floor1Button.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {

            LiftUI.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            LiftUI.SetActive(false);

        }
    }

    public void floor1()
    {
        if (started == false)
        {
            Destroy(LiftUI);
            StartCoroutine(Floor1(5));
        }
        
    }

    IEnumerator Floor1(float Time)
    {
        LiftDoorOpen1.SetActive(false);
        LiftDoorOpen2.SetActive(false);
        LiftDoorClose1.SetActive(true);
        LiftDoorClose2.SetActive(true);
        Fade.SetActive(true);
        LiftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("Test Scene 2");
    }

    public void floor2()
    {
        if (started == false && Floor2Unlocked == true)
        {
            Destroy(LiftUI);
            StartCoroutine(Floor2(5));
        }
        else if (Floor2Unlocked == false)
        {
            ErrorNoise.Play();
        }

    }

    IEnumerator Floor2(float Time)
    {
        LiftDoorOpen1.SetActive(false);
        LiftDoorOpen2.SetActive(false);
        LiftDoorClose1.SetActive(true);
        LiftDoorClose2.SetActive(true);
        Fade.SetActive(true);
        LiftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("Floor 2");
    }

    public void floor3()
    {
        if (started == false && Floor3Unlocked == true)
        {
            Destroy(LiftUI);
            StartCoroutine(Floor3(5));
        }
        else if (Floor3Unlocked == false)
        {
            ErrorNoise.Play();
        }

    }

    IEnumerator Floor3(float Time)
    {
        LiftDoorOpen1.SetActive(false);
        LiftDoorOpen2.SetActive(false);
        LiftDoorClose1.SetActive(true);
        LiftDoorClose2.SetActive(true);
        Fade.SetActive(true);
        LiftClosing.Play();
        animator.SetTrigger(triggerName);
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("Floor 3");
    }
}
