using UnityEngine;
using UnityEngine.Serialization;

public class SellButton : MonoBehaviour
{
    private InvManager _invManager;
    private Upgrades _upgrades;
    [SerializeField] private AudioSource sellSound;
    
    // Start is called before the first frame update
    private void Start()
    {
        _invManager = FindObjectOfType<InvManager>();
        _upgrades = FindObjectOfType<Upgrades>();
    }

    // Update is called once per frame
    public void Sell()
    {

        var items = _invManager.itemName;
        sellSound.Play();

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
