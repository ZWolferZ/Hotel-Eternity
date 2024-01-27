using System.Collections;
using UnityEngine;
using static Monsters;

public class BoxTestEnemy : MonoBehaviour
{
    public Health Health;
    MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();
    private bool cooldown = false;
    private bool isinTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldown == false)
        {
            isinTrigger = true;
            StartCoroutine(WaitAndDamage(1));
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
}
