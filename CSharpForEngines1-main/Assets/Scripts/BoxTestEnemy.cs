using System.Collections;
using UnityEngine;
using static Monsters;

public class BoxTestEnemy : MonoBehaviour 
{
    public Health Health;
    MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();
    private bool cooldown = false;
    private bool isinTrigger = false;
    private bool Stunned = false;
    public Transform playerTransform;
    private Vector2 Target;
    private Vector2 Current;

    void Start()
    {
        
        Target = new Vector2(playerTransform.position.x, playerTransform.position.y);
        Current = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        if (Stunned == false)
        {
            transform.position = Vector2.MoveTowards(Current, Target, BoxTest.speed * Time.deltaTime);
        }
        else
        {

        }
        
        

        
        Current = new Vector2(transform.position.x, transform.position.y);
        Target = new Vector2(playerTransform.position.x, playerTransform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldown == false)
        {
            isinTrigger = true;
            StartCoroutine(WaitAndDamage(1));
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Stun(1));

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isinTrigger = false;
        }
    }

    IEnumerator WaitAndDamage(float time)
    {
        cooldown = true;
        yield return new WaitForSeconds(time);
        Health.health -= BoxTest.damage;

        Debug.Log("Player damaged! Current Health: " + Health.health);
        cooldown = false;

        if (isinTrigger == true)
        {
            
            StartCoroutine(WaitAndDamage(time));
        }
    }

    IEnumerator Stun(float time)
    {
        Stunned = true;
        yield return new WaitForSeconds(time);
        Stunned = false;
    }
}
