using UnityEngine;


public class SellButton : MonoBehaviour
{
    // Initialising variables
    private InvManager _invManager;
    private Upgrades _upgrades;
    [SerializeField] private AudioSource sellSound;
    
    // Gather scripts
    private void Start()
    {
        _invManager = FindObjectOfType<InvManager>();
        _upgrades = FindObjectOfType<Upgrades>();
    }

   // On button click, play the sell noise
    public void Sell()
    {

        var items = _invManager.itemName;
        sellSound.Play();

        // For each item in inventory, add money and discard the item
        foreach (var loot in items)
        {
            switch (loot)
            {
                case "TestLoot":
                    _upgrades.money += Loot.LootTypes.TestLoot.Value;
                    break;
                case "Floor1Loot":
                    _upgrades.money += Loot.LootTypes.Floor1Loot.Value;
                    break;
                case "Floor2Loot":
                    _upgrades.money += Loot.LootTypes.Floor2Loot.Value;
                    break;
                case "Floor3Loot":
                    _upgrades.money += Loot.LootTypes.Floor3Loot.Value;
                    break;
            }
        }

        _invManager.DiscardInvSlot1();
        _invManager.DiscardInvSlot2();
        _invManager.DiscardInvSlot3();
        _invManager.DiscardInvSlot4();
        _invManager.DiscardInvSlot5();
        _invManager.DiscardInvSlot6();
        
    }
}
