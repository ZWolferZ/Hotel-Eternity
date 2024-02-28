using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    // Initialising variables
    private Animator _animator;
    public GameObject[] upgradeUI;
    public bool inTigger;
    
    // ID-ing trigger names 
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int Down = Animator.StringToHash("Down");

    // Finding player camera animator
    private void Start()
    {
        _animator = FindObjectOfType<Camera>().GetComponent<Animator>();
    }

    // On trigger enter, raise camera and turn on UI
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        _animator.SetTrigger(Up);
        upgradeUI[0].SetActive(true);
        upgradeUI[1].SetActive(true);
        inTigger = true;

    }
    
    // On trigger exit, lower camera and turn off UI
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _animator.SetTrigger(Down);
        upgradeUI[0].SetActive(false);
        upgradeUI[1].SetActive(false);
        inTigger = false;
    }
}
