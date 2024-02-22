using UnityEngine;

public abstract class Monsters : MonoBehaviour
{
    

    public abstract class MonsterTypes
    {
        public class MonsterTest 
        {         
            public int Health = 100;
            public const float Damage = 25;
            public const float Speed = 2;
            public int AttackSpeed = 10;
            public float StoppingDistance = 1f;
           public bool PlayerInRange = false;
           public const float ForgetTimer = 7f;
        }
       public class Floor1Monsters
        {
            public const float Damage = 25;
            public const float Speed = 2;
            public bool PlayerInRange = false;
            public const float ForgetTimer = 7f;
        }

       public  class Floor2Monsters
        {
            public int Health = 150;
            public const float Damage = 50;
            public float Speed = 3;
            public int AttackSpeed = 12;
            public float StoppingDistance = 1f;
            public float ForgetTimer = 15;
        }

    }


}
