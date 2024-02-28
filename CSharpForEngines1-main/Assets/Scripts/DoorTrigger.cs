using System.Collections;
using UnityEngine;


public class DoorTrigger : MonoBehaviour
{
    // Initialising variables
    public GameObject door;
    private TopDownCharacterController _topDownCharacterController;
    private Animator _animator;
    public AudioSource doorShutSound;
    
    
    private bool _speed = true;
    private bool _once;
    
    // ID-ing trigger names
    private static readonly int On = Animator.StringToHash("On");


    // Find player controller and camera animator 
    private void Awake()
    {
        _topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
        _animator = FindObjectOfType<Camera>().GetComponent<Animator>();

    }

    // When player is in the trigger, Stop the player, move the camera down, shut the doors
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

    // Set player speed to 0
    private void Update()
    {
        if (!_speed)
        {
            _topDownCharacterController.playerMaxSpeed = 0;
        }
    }


    // Wait for four seconds and them set a bool to true
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        _speed = true;
    }   

}
