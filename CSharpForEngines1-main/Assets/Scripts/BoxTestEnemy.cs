using System.Collections;
using UnityEngine;
using static Monsters;
using UnityEngine.AI;

public class BoxTestEnemy : MonoBehaviour
{
    public Health Health;
    MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();
    private bool cooldown = false;
    private bool Collider = false;
    private bool Stunned = false;
    public Transform playerTransform;
   

    void Start()
    {
        
        playerTransform = FindObjectOfType<TopDownCharacterController>().transform;
    }

    void Update()
    {
        if (Stunned == false)
        {
            if (BoxTest.PlayerInRange == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, BoxTest.speed * Time.deltaTime);
            }
            else
            {
                // Nothing
            }

        }
        else
        {
            // Nothing
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
          StartCoroutine(WaitAndBool(10));
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
        yield return new WaitForSeconds(time);
        BoxTest.PlayerInRange = false;
    }
    IEnumerator Stun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
}
