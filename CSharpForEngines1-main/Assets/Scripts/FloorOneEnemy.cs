using System.Collections;
using UnityEngine;
using static Monsters;
using UnityEngine.AI;



public class FloorOneEnemy : MonoBehaviour
{
    #region Varibles

    // List of variables needed (You probably don't need half of these)
    private Health health;
    private readonly MonsterTypes.Floor1Monsters Type1 = new MonsterTypes.Floor1Monsters();
    private bool _cooldown;
    private bool _collider;
    private bool _stunned;
    private Transform playerTransform;
    private NavMeshAgent _mAgent;
    private bool _lineOfSight;
    [SerializeField] private bool foundPlayer;
    [SerializeField] private bool roaming = true;
    private bool _moveCooldown;
    public GameObject enemyLight;
    private bool _triggerCooldown;
    private TopDownCharacterController player;
    #endregion


    #region Assigning Varibles

    private void Start()
    {
        // Assigning Starting Variables
        playerTransform = FindObjectOfType<TopDownCharacterController>().transform;
        _mAgent = GetComponent<NavMeshAgent>();
        _mAgent.speed = MonsterTypes.Floor1Monsters.Speed;
        player = FindAnyObjectByType<TopDownCharacterController>();
        health = FindAnyObjectByType<Health>();

    }

    #endregion

    #region Raycast Detection
    private void FixedUpdate()
    {
        var enemyPosition = transform.position;
        // Enemy RayCast Detection
        RaycastHit2D hit = Physics2D.Raycast(enemyPosition, playerTransform.transform.position - enemyPosition);
        if(hit.collider == null) return;
        {
            _lineOfSight = hit.collider.CompareTag("Player");    
            
            switch (_lineOfSight)
            {
                case true:
                    // If line of sight = true the line will draw as green
                    Debug.DrawRay(transform.position, playerTransform.transform.position - enemyPosition, Color.green);
                    break;
                case false:
                    // If line of sight != true the line will draw as red
                    Debug.DrawRay(transform.position, playerTransform.transform.position - enemyPosition, Color.red);
                    break;
            }

        }

    }
    #endregion

    #region Update Enemy Detection and Movement

    private void Update()
    {
        switch (_stunned)
        {
            case false:
            {
                // Set booleans if player is in the trigger and and the enemy has a line of sight
                if (Type1.PlayerInRange && _lineOfSight)
                {

                    foundPlayer = true;
                    roaming = false;
               
                }
                else if (_lineOfSight == false)
                {
                    if (_triggerCooldown == false)
                    {
                        // If line of sight is lost, start the forget timer
                        StartCoroutine(WaitAndBool(MonsterTypes.MonsterTest.ForgetTimer));

                    }


                }
                if (roaming && _moveCooldown == false)
                {
                    // If roaming = true, the enemy will start to move randomly
                    StartCoroutine(Roam());
                    
                }

                switch (foundPlayer)
                {
                    case true:
                        // If player is found turn on the enemy's detection light
                        enemyLight.SetActive(true);
                        // Move towards the player
                        _mAgent.SetDestination(playerTransform.position);
                        break;
                
                    case false:
                        // If player is not found turn off the enemy's detection light
                        enemyLight.SetActive(false);
                        break;
                }

                break;
            }
            case true:
                // If the enemy is stunned do not move
                _mAgent.SetDestination(transform.position);
                break;
        }
    }

    #endregion 

    #region Collision Detectors

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _cooldown == false)
        {
            _collider = true;
            // If the player is collided with,start the damage coroutine
            StartCoroutine(WaitAndDamage(1));
        }
        if (!collision.gameObject.CompareTag("Bullet")) return;
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
            _collider = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Type1.PlayerInRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Type1.PlayerInRange = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Type1.PlayerInRange = true;
        }
    }

    #endregion
    
    #region Coroutines

    // Wait and damage the player after a delay
    private IEnumerator WaitAndDamage(float time)
    {
        _cooldown = true;
        health.health -= MonsterTypes.MonsterTest.Damage;
        
        
        yield return new WaitForSeconds(time);
       

        Debug.Log("Player damaged! Current Health: " + health.health);
        _cooldown = false;

        if (_collider)
        {
            StartCoroutine(WaitAndDamage(time));
        }
    }

    // Start the forget timer
    private IEnumerator WaitAndBool(float time)
    {
        _triggerCooldown = true;
        yield return new WaitForSeconds(time);
        foundPlayer = false;
        _triggerCooldown = false;
        roaming = true;
        
    }
    // Wait for "time" and trigger the stunned boolean
    private IEnumerator Stun(float time)
    {
        _stunned = true;
        yield return new WaitForSeconds(time);
        _stunned = false;
    }
    // Make the enemy randomly move 
    private IEnumerator Roam()
    {
        _moveCooldown = true;

        // Call the random location function and get a random point on the navmesh
        Vector2 randomPoint = RandomLocation();

        // Go to the random point on the navmesh
        _mAgent.SetDestination(randomPoint);

        yield return new WaitForSeconds(2);
        _moveCooldown = false;
    }
    #endregion 

    #region Vector3 Function
    // Get a random location on the navmesh
    private Vector3 RandomLocation()
    {
        
        const float roamingRadius = 10f;

        var randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection += transform.position;

        NavMesh.SamplePosition(randomDirection, out var navHit, roamingRadius, NavMesh.AllAreas);
       
        return navHit.position;
        
    }

    #endregion 
}
