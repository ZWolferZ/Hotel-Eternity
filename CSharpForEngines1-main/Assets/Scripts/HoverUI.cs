using UnityEngine;
using UnityEngine.EventSystems;
using static Loot;


public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    // Initialising variables
    public GameObject invSlotDetail;
    public GameObject discardButton;
    public InvManager invManager;
    public TMPro.TextMeshProUGUI uitext;
    public bool[] slots;
    public bool noFire;
    
    // Initialising text
    private void Start()
    {
        uitext.text = "EMPTY SLOT";
    }

    // Keep inventory detail panels updated (This is inefficient, I know)
    private void FixedUpdate()
    {
        UpdateSlot(0);
        UpdateSlot(1);
        UpdateSlot(2);
        UpdateSlot(3);
        UpdateSlot(4);
        UpdateSlot(5);
    }

    // Update Inventory detail panels based on the name of the item.
    private void UpdateSlot(int slotIndex)
    {
        switch (invManager.inventorySlotOpen[slotIndex])
        {
            
            case true when slots[slotIndex]:
                uitext.text = "EMPTY SLOT";
                break;
            case false when slots[slotIndex]:
            {
                // If item text is empty do nothing
                if (invManager.itemName[slotIndex] == "Empty")
                {
                    uitext.text = "EMPTY SLOT";
                }
                // Display information based on the item name
                if (invManager.itemName[slotIndex] == "TestLoot")
                {
                    var testLoot = new LootTypes.TestLoot
                    {
                        Name = invManager.itemName[slotIndex]
                    };
                    invManager.slotWeight[slotIndex] = LootTypes.TestLoot.Weight;
                    uitext.text = testLoot.Name + "\n" + "\n" + "Weight: " + LootTypes.TestLoot.Weight + "\n" + "\n" + "Value: " + LootTypes.TestLoot.Value;
                }
                // Display information based on the item name
                if (invManager.itemName[slotIndex] == "Floor1Loot")
                {
                    var floor1Loot = new LootTypes.Floor1Loot
                    {
                        Name = invManager.itemName[slotIndex]
                    };
                    invManager.slotWeight[slotIndex] = LootTypes.Floor1Loot.Weight;
                    uitext.text = floor1Loot.Name + "\n" + "\n" + "Weight: " + LootTypes.Floor1Loot.Weight + "\n" + "\n" + "Value: " + LootTypes.Floor1Loot.Value;
                }
                // Display information based on the item name
                if (invManager.itemName[slotIndex] == "Floor2Loot")
                {
                    var floor2Loot = new LootTypes.Floor2Loot
                    {
                        Name = invManager.itemName[slotIndex]
                    };
                    invManager.slotWeight[slotIndex] = LootTypes.Floor2Loot.Weight;
                    uitext.text = floor2Loot.Name + "\n" + "\n" + "Weight: " + LootTypes.Floor2Loot.Weight + "\n" + "\n" + "Value: " + LootTypes.Floor2Loot.Value;
                }
                // Display information based on the item name
                if (invManager.itemName[slotIndex] == "Floor3Loot")
                {
                    var floor3Loot = new LootTypes.Floor3Loot
                    {
                        Name = invManager.itemName[slotIndex]
                    };
                    invManager.slotWeight[slotIndex] = LootTypes.Floor3Loot.Weight;
                    uitext.text = floor3Loot.Name + "\n" + "\n" + "Weight: " + LootTypes.Floor3Loot.Weight + "\n" + "\n" + "Value: " + LootTypes.Floor3Loot.Value;
                }
                break;
            }
        }
    }

    // If the mouse is hover inside it, display information
    public void OnPointerEnter(PointerEventData mouse)
    {
        if (invSlotDetail == null) return;
        noFire = true;
        discardButton.SetActive(true);
        invSlotDetail.SetActive(true);
    }


    // Switch off information, if mouse leaves
    public void OnPointerExit(PointerEventData mouse)
    {
        if (invSlotDetail == null) return;
        noFire = false;
        discardButton.SetActive(false);
        invSlotDetail.SetActive(false);
    }
}
