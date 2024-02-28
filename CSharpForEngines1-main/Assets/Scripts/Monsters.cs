using UnityEngine;

public abstract class Monsters : MonoBehaviour
{
    
// Data holder
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
            public const float Damage = 40;
            public const float Speed = 2.5f;
            public bool PlayerInRange = false;
            public const float ForgetTimer = 7f;
        }
       public  class Floor3Monsters
    {
        public const float Damage = 50;
        public const float Speed = 3f;
        public bool PlayerInRange = false;
        public const float ForgetTimer = 7f;
    }
    }
    

}


