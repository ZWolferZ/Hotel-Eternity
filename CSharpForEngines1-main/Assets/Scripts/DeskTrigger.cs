using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class DeskTrigger : MonoBehaviour
{
    // Initialising variables
    public Animator animator;
    public Animator hotelguyAnimator;
    private bool _once;
    private bool _intrigger;
    private bool _continue;
    private bool _continue2;
    private bool _endconvo;
    [FormerlySerializedAs("_Dialougebox")] public GameObject dialougebox;
    [FormerlySerializedAs("_text")] public GameObject[] text;
    private LevelSwitch _levelSwitch;
    public AudioSource textBlip;
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int Down = Animator.StringToHash("Down");
    private static readonly int Appear = Animator.StringToHash("Appear");
    private static readonly int Idle = Animator.StringToHash("Idle");

    // Finding level switch script
    private void Awake()
    {
        _levelSwitch = FindObjectOfType<LevelSwitch>();
    }


    // On trigger enter, raise camera and switch bool on
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        animator.SetTrigger(Up);
        _intrigger = true;
    }

    // On trigger exit, lower camera and switch bool off
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _intrigger = false;
        animator.SetTrigger(Down);

    }

    private void Update()
    {
        // Open lift doors if the conversion is over
        if (_endconvo)
        {
            _levelSwitch.liftOpening.Play();
            _levelSwitch.liftDoorClose1.SetActive(false);
            _levelSwitch.liftDoorClose2.SetActive(false);
            _levelSwitch.liftDoorOpen1.SetActive(true);
            _levelSwitch.liftDoorOpen2.SetActive(true);
            _endconvo = false;
        }
        
        // Dialogue triggers
        if (_once == false && _intrigger)
        {
            
            StartCoroutine(WaitContinue1(2));
           _once = true;
                       
                
        } 
        if (_continue)
        {
            hotelguyAnimator.SetTrigger(Appear);
            StartCoroutine(WaitContinue2(4));
            _continue = false;
         
            
        }

        if (!_continue2) return;
        hotelguyAnimator.SetTrigger(Idle);
        StartCoroutine(WaitText());
        _continue2 = false;
    }
    
    // Dialogue Coroutines
    private IEnumerator WaitContinue1(float time)
    {
        
        yield return new WaitForSeconds(time);
        _continue = true;

    }   
    
    private IEnumerator WaitContinue2(float time)
    {
        yield return new WaitForSeconds(time);
        _continue2 = true;

    }  
    
    // For each text in the array, play sound and display text
    private IEnumerator WaitText()
    {
        const float waittime = 4f;
        dialougebox.SetActive(true);

        foreach (var t in text)
        {
            textBlip.Play();
            t.SetActive(true);
            yield return new WaitForSeconds(waittime);
            t.SetActive(false);
        }
        
        dialougebox.SetActive(false);
        _endconvo = true;
    }
}
