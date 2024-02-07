using UnityEngine;
using UnityEngine.UI;

public class TestLoot : MonoBehaviour
{
    public GameObject LootPrefabTest; 
    public PlayerWeight playerWeight;
    public TopDownCharacterController topDownCharacterController;
    public InvManager invManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invManager.inventoryFull == false)
        {
            Loot.LootTypes.TestLoot Loot1 = new Loot.LootTypes.TestLoot();
            Loot1.item = LootPrefabTest;
            playerWeight.weight += Loot1.Weight;
            
            invManager.AddItemToInventory(Loot1.item);
            playerWeight.CarryWeight.text = "Carry Weight: " + playerWeight.weight;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Inventory Full");
        }
    }
}

