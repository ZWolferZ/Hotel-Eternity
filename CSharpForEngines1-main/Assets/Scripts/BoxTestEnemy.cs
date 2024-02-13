using System.Collections;
using UnityEngine;
using static Monsters;
using UnityEngine.AI;

using UnityEngine.UIElements;
using UnityEngine.Rendering.Universal;

public class BoxTestEnemy : MonoBehaviour
{
    #region Varibles

    // List of varibles needed (You probably don't need half of these)
    public Health Health;
    MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();
    private bool cooldown = false;
    private bool Collider = false;
    private bool Stunned = false;
    public Transform playerTransform;
    NavMeshAgent m_Agent;
    private bool LineOfSight = false;
    [SerializeField] bool foundPlayer = false;
    [SerializeField] bool Roaming = true;
    bool moveCooldown = false;
    public GameObject enemyLight;
    private bool triggerCooldown = false;
    public TopDownCharacterController Player;
    #endregion


    #region Assigning Varibles

    void Start()
    {
        // Assigning Starting Varibles
        playerTransform = FindObjectOfType<TopDownCharacterController>().transform;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = BoxTest.speed;
        Player = FindAnyObjectByType<TopDownCharacterController>();
        Health = FindAnyObjectByType<Health>();

    }

    #endregion

    #region Raycast Detection
    private void FixedUpdate()
    {
        // Enemy RayCast Detection
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.transform.position - transform.position);
        if(hit.collider != null)
        {
            LineOfSight = hit.collider.CompareTag("Player");    
            if(LineOfSight == true)
            {
                // If line of sight = true the line will draw as green
                Debug.DrawRay(transform.position, playerTransform.transform.position - transform.position, Color.green);
            }
            else if (LineOfSight == false)
            {
                // If line of sight != true the line will draw as red
                Debug.DrawRay(transform.position, playerTransform.transform.position - transform.position, Color.red);
            }
        }

    }
    #endregion

    #region Update Enemy Detection and Movement

    void Update()
    {
        if (Stunned == false)
        {
            // Set bools if player is in thetrigger and and the enemy has a line of sight
            if (BoxTest.PlayerInRange == true && LineOfSight == true)
            {

                foundPlayer = true;
                Roaming = false;
               
            }
            else if (LineOfSight == false)
            {
                if (triggerCooldown == false)
                {
                    // If line of sight is lost, start the forget timer
                   StartCoroutine(WaitAndBool(BoxTest.ForgetTimer));

                }


            }
            if (Roaming == true && moveCooldown == false)
            {
                // If roaming = true, the enemy will start to move randomly
                StartCoroutine(Roam());
                    
            }

            if (foundPlayer == true)
            {
                // If player is found turn on the enemys detection light
                enemyLight.SetActive(true);
                // Move towards the player
                m_Agent.SetDestination(playerTransform.position);
            }
            if (foundPlayer == false)
            {
                // If player is not found turn off the enemys detection light
                enemyLight.SetActive(false);
            }
        }
        else if (Stunned == true)
        {
            // If the enemy is stunned do not move
            m_Agent.SetDestination(transform.position);
        }
        
        
    }

    #endregion 

    #region Collision Detectors

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && cooldown == false)
        {
            Collider = true;
            // If the player is collided with,start the damage coroutine
            StartCoroutine(WaitAndDamage(1));
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // If hit with a bullet, Destroy the bullet and start the stun coroutine
            Destroy(collision.gameObject);
            StartCoroutine(Stun(1));
        }
    }

    // Logic gates
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

    #endregion 


    #region Coroutines

    // Wait and damage the player after a delay
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

    // Start the forget timer
    IEnumerator WaitAndBool(float time)
    {
        triggerCooldown = true;
        yield return new WaitForSeconds(time);
        foundPlayer = false;
        triggerCooldown = false;
        Roaming = true;
        
    }
    // Wait for "time" and trigger the stunned boolean
    IEnumerator Stun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
    // Make the enemy randomly move 
    IEnumerator Roam()
    {
        moveCooldown = true;

        // Call the random location function and get a random point on the navmesh
        Vector2 randomPoint = randomLocation();

        // Go to the random point on the navmesh
        m_Agent.SetDestination(randomPoint);

        yield return new WaitForSeconds(2);
        moveCooldown = false;
    }
    #endregion 

    #region Vector3 Function
    // Get a random location on the navmesh
    private Vector3 randomLocation()
    {
        
        float roamingRadius = 10f;

        Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, roamingRadius, NavMesh.AllAreas);
       
        return navHit.position;
        
    }

    #endregion 
}
