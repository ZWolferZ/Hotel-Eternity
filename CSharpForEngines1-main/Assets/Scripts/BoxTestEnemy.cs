using System.Collections;
using UnityEngine;
using static Monsters;
using UnityEngine.AI;
using UnityEditor.AI;

public class BoxTestEnemy : MonoBehaviour
{
    public Health Health;
    MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();
    private bool cooldown = false;
    private bool Collider = false;
    private bool Stunned = false;
    public Transform playerTransform;
    NavMeshAgent m_Agent;

     bool LineOfSight = false;

    void Start()
    {
        
        playerTransform = FindObjectOfType<TopDownCharacterController>().transform;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = BoxTest.speed;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.transform.position - transform.position);
        if(hit.collider != null)
        {
            LineOfSight = hit.collider.CompareTag("Player");    
            if(LineOfSight == true)
            {
                Debug.DrawRay(transform.position, playerTransform.transform.position - transform.position, Color.green);
            }
            else if (LineOfSight == false)
            {
                Debug.DrawRay(transform.position, playerTransform.transform.position - transform.position, Color.red);
            }
        }

    }
    void Update()
    {
        if (Stunned == false)
        {
            if (BoxTest.PlayerInRange == true && LineOfSight == true)
            {
                m_Agent.SetDestination(playerTransform.position);
            }
            else if (BoxTest.PlayerInRange == false)
            {
                m_Agent.SetDestination(transform.position);
            }

        }
        else if (Stunned == true)
        {
            m_Agent.SetDestination(transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldown == false)
        {
            Collider = true;
            StartCoroutine(WaitAndDamage(1));
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Stun(1));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BoxTest.PlayerInRange = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BoxTest.PlayerInRange = true;
        }
    }
    bool triggerCooldown = false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && triggerCooldown == false)
        {
          StartCoroutine(WaitAndBool(BoxTest.ForgetTimer));
        }
        if (collision.gameObject.CompareTag("Player") && LineOfSight == false)
        {
            BoxTest.PlayerInRange = false;
        }
        
    }

    IEnumerator WaitAndDamage(float time)
    {
        cooldown = true;
        Health.health -= BoxTest.damage;
        yield return new WaitForSeconds(time);
        

        Debug.Log("Player damaged! Current Health: " + Health.health);
        cooldown = false;

        if (Collider == true)
        {
            StartCoroutine(WaitAndDamage(time));
        }
    }

    IEnumerator WaitAndBool(float time)
    {
        triggerCooldown = true;
        yield return new WaitForSeconds(time);
        BoxTest.PlayerInRange = false;
        triggerCooldown = false;
    }
    IEnumerator Stun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
}
