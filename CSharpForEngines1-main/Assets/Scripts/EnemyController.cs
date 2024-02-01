using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform m_Player;
    NavMeshAgent m_Agent;
    public bool m_sighted = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = FindAnyObjectByType<TopDownCharacterController>().transform;
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( m_sighted == true)
        {
            m_Agent.SetDestination(m_Player.position);
        }
        
    }


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

     IEnumerator WaitandBool (float time)
    {
        yield return new WaitForSeconds(time);
        m_sighted = false;
    }
}
