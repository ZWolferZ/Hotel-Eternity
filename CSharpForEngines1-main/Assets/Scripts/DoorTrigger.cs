
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    private TopDownCharacterController _topDownCharacterController;
    public Animator animator;
    
    
    private bool _speed = true;
    private bool _once;
    private static readonly int On = Animator.StringToHash("On");


    private void Awake()
    {
        _topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || _once) return;
        _once = true;
        _speed = false;
        door.SetActive(true);
        animator.SetTrigger(On);
        StartCoroutine(Wait());
    }

    private void Update()
    {
        _topDownCharacterController.playerMaxSpeed = !_speed ? 0 : 190;
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        _speed = true;
    }   

}
