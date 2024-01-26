using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Monsters;

public class BoxTest : Monsters.MonsterTypes.MonsterTEST
{
    public GameObject Box;
    public Health Health;
    
    // Start is called before the first frame update
    void Awake()
    {
        MonsterTypes.MonsterTEST BoxTest = new MonsterTypes.MonsterTEST();

        BoxTest.damage = 5 * Time.deltaTime;

        Box.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health.health -= damage;
        }
    }
    void OnCollisionExit(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health.health += 0;
        }
    }
}
