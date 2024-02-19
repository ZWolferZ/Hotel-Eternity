using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    public abstract class LootTypes
    {
        public class TestLoot
        {
            public const int Value = 10;
            public const int Weight = 1;
           public GameObject Item;
            public string Name;

        }
        public class Floor1Loot
        {
            public const int Value = 10;
            public const int Weight = 1;
            public GameObject Item;
            public string Name;
        }

       public  class Floor2Loot
        {
            public const int Value = 15;
            public const int Weight = 2;
            public GameObject Item;
            public string Name;

        }
    }
}
