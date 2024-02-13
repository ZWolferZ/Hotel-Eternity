using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#region Starter Reference Enemy Script (Not Used)

public class EnemyController : MonoBehaviour
{
    // Varibles
    public Transform m_Player;
    NavMeshAgent m_Agent;
    public bool m_sighted = false;

    
    void Start()
    {
        // Inisilise Varibles 
        m_Player = FindAnyObjectByType<TopDownCharacterController>().transform;
        m_Agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        // If the player is sighted, move towards the player
        if ( m_sighted == true)
        {
            m_Agent.SetDestination(m_Player.position);
        }
        
    }

    // Triggers for booleans
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_sighted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitandBool(5f));
        }
    }
    // Forget Timer Coroutine
     IEnumerator WaitandBool (float time)
    {
        yield return new WaitForSeconds(time);
        m_sighted = false;
    }
}

#endregion