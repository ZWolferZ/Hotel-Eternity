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
            public float damage = 10;
            public float speed = 1;
            public int attackSpeed = 10;
                   
        }
       public class Floor1Monsters
        {
            public int health = 100;
            public int damage = 10;
            public float speed = 2;
            public int attackSpeed = 10;
        }

       public  class Floor2Monsters
        {
            public int health = 150;
            public int damage = 20;
            public float speed = 3;
            public int attackSpeed = 12;
        }
    } 
   
}
