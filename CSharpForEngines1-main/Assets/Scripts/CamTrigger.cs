using UnityEngine;



public class CamTrigger : MonoBehaviour
{
    private Animator _animator;
    public GameObject[] upgradeUI;
    public bool inTigger;
    
    private static readonly int Up = Animator.StringToHash("Up");
    private static readonly int Down = Animator.StringToHash("Down");
    // Start is called before the first frame update
    private void Start()
    {
        _animator = FindObjectOfType<Camera>().GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        _animator.SetTrigger(Up);
        upgradeUI[0].SetActive(true);
        upgradeUI[1].SetActive(true);
        inTigger = true;

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _animator.SetTrigger(Down);
        upgradeUI[0].SetActive(false);
        upgradeUI[1].SetActive(false);
        inTigger = false;
    }
}
