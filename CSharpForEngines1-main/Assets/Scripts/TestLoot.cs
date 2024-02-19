using UnityEngine;
using UnityEngine.Serialization;


public class TestLoot : MonoBehaviour
{
    [FormerlySerializedAs("LootPrefabTest")] public GameObject lootPrefabTest; 
    public PlayerWeight playerWeight;
    public TopDownCharacterController topDownCharacterController;
    public InvManager invManager;

    private void Awake()
    {
        topDownCharacterController = FindAnyObjectByType<TopDownCharacterController>();
        invManager = FindAnyObjectByType<InvManager>();
        playerWeight = FindAnyObjectByType<PlayerWeight>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invManager.inventoryFull == false)
        {
            var loot1 = new Loot.LootTypes.TestLoot
            {
                Item = lootPrefabTest
            };
            playerWeight.weight += Loot.LootTypes.TestLoot.Weight;
            
            invManager.AddItemToInventory(loot1.Item);
            playerWeight.carryWeight.text = "Carry Weight: " + playerWeight.weight;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Inventory Full");
        }
    }
}

