using System.Collections;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private TopDownCharacterController _player;
    private static readonly int End = Animator.StringToHash("End");
    [SerializeField] private GameObject sleepButton;
    
    

    private void FixedUpdate()
    {
        _player = FindAnyObjectByType<TopDownCharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        sleepButton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        sleepButton.SetActive(false);
    }

    public void Endbutton()
    {
        _player.End = true;
        Destroy(sleepButton);
        _player._animator.SetTrigger(End);
        StartCoroutine(Load(6f));
    }
    
    private static IEnumerator Load(float time)
    {
        
        yield return new WaitForSeconds(time);
        Application.Quit();
        
        
    }
}
