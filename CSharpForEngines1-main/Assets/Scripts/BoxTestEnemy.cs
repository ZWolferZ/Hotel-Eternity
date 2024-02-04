using System.Collections;
using UnityEngine;
using static Monsters;
using UnityEngine.AI;
using UnityEditor.AI;
using UnityEngine.UIElements;
using UnityEngine.Rendering.Universal;

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
    [SerializeField] bool foundPlayer = false;
    [SerializeField] bool Roaming = true;
    bool moveCooldown = false;
    public GameObject enemyLight;
  
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

                foundPlayer = true;
                Roaming = false;
               
            }
            else if (LineOfSight == false)
            {
                if (triggerCooldown == false)
                {
            StartCoroutine(WaitAndBool(BoxTest.ForgetTimer));

                }

                


            }
            if (Roaming == true && moveCooldown == false)
            {
                StartCoroutine(Roam());
                    
            }

            if (foundPlayer == true)
            {
                enemyLight.SetActive(true);
                m_Agent.SetDestination(playerTransform.position);
            }
            if (foundPlayer == false)
            {
                enemyLight.SetActive(false);
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
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            BoxTest.PlayerInRange = false;
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
        foundPlayer = false;
        triggerCooldown = false;
        Roaming = true;
        
    }
    IEnumerator Stun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
    IEnumerator Roam()
    {
        moveCooldown = true;
        
        Vector2 randomPoint = randomLocation();

        
        m_Agent.SetDestination(randomPoint);

        yield return new WaitForSeconds(2);
        moveCooldown = false;
    }

    private Vector3 randomLocation()
    {
        
        float roamingRadius = 10f;

        Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, roamingRadius, NavMesh.AllAreas);
       
        return navHit.position;
        
    }

}
