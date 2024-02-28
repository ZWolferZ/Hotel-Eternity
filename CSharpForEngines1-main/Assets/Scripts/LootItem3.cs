using System.Collections;
using UnityEngine;



public class LootItem3 : MonoBehaviour
{
    public GameObject lootPrefab; 
    private PlayerWeight playerWeight;
    private InvManager invManager;
    

    // Start script gather
    private void Awake()
    {
        StartCoroutine(Begin(0.1f));
        
        
    }

    // On trigger, if inventory is not full, add to weight counter , add to inventory, destroy item
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || invManager.inventoryFull)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Inventory Full");
            }
        }
        else
        {
            var loot3 = new Loot.LootTypes.Floor3Loot()
            {
                Item = lootPrefab
            };
            playerWeight.weight += Loot.LootTypes.Floor3Loot.Weight;

            invManager.AddItemToInventory(loot3.Item);
            playerWeight.carryWeight.text = "Carry Weight: " + playerWeight.weight;
            Destroy(gameObject);
        }
    }
    
    // Gather scripts after time
    private IEnumerator Begin(float time)
    {
        
        yield return new WaitForSeconds(time);
        invManager = FindAnyObjectByType<InvManager>();
        playerWeight = FindAnyObjectByType<PlayerWeight>();


    } 
}

