using System.Collections;
using UnityEngine;


public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    private TopDownCharacterController _topDownCharacterController;
    private Animator _animator;
    public AudioSource doorShutSound;
    
    
    private bool _speed = true;
    private bool _once;
    private static readonly int On = Animator.StringToHash("On");


    private void Awake()
    {
        _topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
        _animator = FindObjectOfType<Camera>().GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || _once) return;
        _once = true;
        _speed = false;
        door.SetActive(true);
        _animator.SetTrigger(On);
        doorShutSound.Play();
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if (!_speed)
        {
            _topDownCharacterController.playerMaxSpeed = 0;
        }
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        _speed = true;
    }   

}
