using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public class LootTypes
    {
        public class TestLoot
        {
           public int Value = 10;
            public int Weight = 1;
            public GameObject item;
            public string Name;

        }
        public class Floor1Loot
        {
            public int Value = 10;
            public int Weight = 1;
            public GameObject item;
            public string Name;
        }

       public  class Floor2Loot
        {
            public int Value = 15;
            public int Weight = 2;
            public GameObject item;
            public string Name;

        }
    }
}
