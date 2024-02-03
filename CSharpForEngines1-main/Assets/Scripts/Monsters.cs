using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{    
    public class MonsterTypes
    {
        public class MonsterTEST 
        {         
            public int health = 100;
            public float damage = 25;
            public float speed = 1;
            public int attackSpeed = 10;
            public float stoppingDistance = 1f;
           public bool PlayerInRange = false;
            public float ForgetTimer = 10;
                   
        }
       public class Floor1Monsters
        {
            public int health = 100;
            public int damage = 45;
            public float speed = 2;
            public int attackSpeed = 10;
            public float stoppingDistance = 1f;
            public float ForgetTimer = 10;
        }

       public  class Floor2Monsters
        {
            public int health = 150;
            public int damage = 50;
            public float speed = 3;
            public int attackSpeed = 12;
            public float stoppingDistance = 1f;
            public float ForgetTimer = 15;
        }

    } 
   
}
