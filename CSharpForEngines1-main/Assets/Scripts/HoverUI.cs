using UnityEngine;
using UnityEngine.EventSystems;
using static Loot;
using static Loot.LootTypes;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject InvSlotDetail;
    public GameObject DiscardButton;
    

    public InvManager InvManager;
    public TMPro.TextMeshProUGUI UITEXT;
    public bool[] Slots;
    public bool noFire = false;
    
    private void Start()
    {
        UITEXT.text = "EMPTY SLOT";
    }

    private void FixedUpdate()
    {
        UpdateSlot(0);
        UpdateSlot(1);
        UpdateSlot(2);
        UpdateSlot(3);
        UpdateSlot(4);
        UpdateSlot(5);
    }

    private void UpdateSlot(int slotIndex)
    {
        if (InvManager.inventorySlotOpen[slotIndex] && Slots[slotIndex])
        {
            UITEXT.text = "EMPTY SLOT";
        }
        else if (InvManager.inventorySlotOpen[slotIndex] == false && Slots[slotIndex] == true)
        {
            if (InvManager.itemName[slotIndex] == "Empty")
            {
                UITEXT.text = "EMPTY SLOT";
            }
            if (InvManager.itemName[slotIndex] == "TestLoot")
            {
                Loot.LootTypes.TestLoot TestLoot = new LootTypes.TestLoot();
                TestLoot.Name = InvManager.itemName[slotIndex];
                InvManager.SlotWeight[slotIndex] = TestLoot.Weight;
                UITEXT.text = TestLoot.Name + "\n" + "\n" + "Weight: " + TestLoot.Weight + "\n" + "\n" + "Value: " + TestLoot.Value;
            }
            if (InvManager.itemName[slotIndex] == "Floor1Loot")
            {
                Loot.LootTypes.Floor1Loot Floor1Loot = new LootTypes.Floor1Loot();
                Floor1Loot.Name = InvManager.itemName[slotIndex];
                InvManager.SlotWeight[slotIndex] = Floor1Loot.Weight;
                UITEXT.text = Floor1Loot.Name + "\n" + "\n" + "Weight: " + Floor1Loot.Weight + "\n" + "\n" + "Value: " + Floor1Loot.Value;
            }
            if (InvManager.itemName[slotIndex] == "Floor2Loot")
            {
                Loot.LootTypes.Floor2Loot Floor2Loot = new LootTypes.Floor2Loot();
                Floor2Loot.Name = InvManager.itemName[slotIndex];
                InvManager.SlotWeight[slotIndex] = Floor2Loot.Weight;
                UITEXT.text = Floor2Loot.Name + "\n" + "\n" + "Weight: " + Floor2Loot.Weight + "\n" + "\n" + "Value: " + Floor2Loot.Value;
            }
        }
    }

    public void OnPointerEnter(PointerEventData Mouse)
    {
        if (InvSlotDetail != null)
        {
            noFire = true;
            DiscardButton.SetActive(true);
            InvSlotDetail.SetActive(true);
        }
    }


    public void OnPointerExit(PointerEventData Mouse)
    {
        if (InvSlotDetail != null)
        {
            noFire = false;
            DiscardButton.SetActive(false);
            InvSlotDetail.SetActive(false);
        }
    }
}
