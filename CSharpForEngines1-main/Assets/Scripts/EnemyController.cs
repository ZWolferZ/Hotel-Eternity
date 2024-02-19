using System.Collections;
using UnityEngine;
using UnityEngine.AI;


#region Starter Reference Enemy Script (Not Used)

public class EnemyController : MonoBehaviour
{
    // Variables
    public Transform mPlayer;
    private NavMeshAgent _mAgent;
    public bool mSighted;


    private void Start()
    {
        // Initialise Variables 
        mPlayer = FindAnyObjectByType<TopDownCharacterController>().transform;
        _mAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        // If the player is sighted, move towards the player
        if (mSighted)
        {
            _mAgent.SetDestination(mPlayer.position);
        }
        
    }

    // Triggers for booleans
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mSighted = true;
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
    private IEnumerator WaitandBool (float time)
    {
        yield return new WaitForSeconds(time);
        mSighted = false;
    }
}

#endregion