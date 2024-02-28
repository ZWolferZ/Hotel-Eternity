using System.Collections;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Initialising variables
    private TopDownCharacterController _player;
    private static readonly int End = Animator.StringToHash("End");
    [SerializeField] private GameObject sleepButton;
    
    

    // Find player controller  
    private void FixedUpdate()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
    }

    // Turn on button
    private void OnTriggerEnter2D(Collider2D other)
    {
        sleepButton.SetActive(true);
    }
    
    // Turn off button
    private void OnTriggerExit2D(Collider2D other)
    {
        sleepButton.SetActive(false);
    }

    // Destroy button, turn on bool, play animation
    public void Endbutton()
    {
        _player.End = true;
        Destroy(sleepButton);
        _player._animator.SetTrigger(End);
        StartCoroutine(Load(6f));
    }
    
    // Quit game after seconds
    private static IEnumerator Load(float time)
    {
        
        yield return new WaitForSeconds(time);
        Application.Quit();
        
        
    }
}
