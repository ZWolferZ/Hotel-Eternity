using UnityEngine;


public class InvManager : MonoBehaviour
{
    public GameObject[] inventorySlots;
    public bool[] inventorySlotOpen;
    public string[] itemName;
    public int[] slotWeight;
    public bool inventoryFull;
    public PlayerWeight playerweight;
    public GameObject invFullUI;

   


    // New Inventory System (Brad told me to start thinking, instead of just doing)
    public void AddItemToInventory(GameObject itemPrefab)
    {
        var newItem = Instantiate(itemPrefab);

        
        for (var i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlotOpen[i] && inventoryFull == false)
            {
                
                newItem.transform.SetParent(inventorySlots[i].transform);
                newItem.transform.localPosition = Vector3.zero;

                if (newItem.name == "Test Loot Sprite(Clone)")
                {
                    newItem.name = "TestLoot";
                }
                
                itemName[i] = newItem.name;
                inventorySlotOpen[i] = false;

                break;
            }
            else if (inventoryFull)
            {
                Debug.Log("Inventory Full");
                


                break;
            }
        }
    }
    public void DiscardInvSlot1()
    {
        var child = inventorySlots[0].transform.GetChild(1).gameObject;
        playerweight.weight = playerweight.weight - slotWeight[0];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[0] = 0;
        inventorySlotOpen[0] = true;
        itemName[0] = "Empty";

        Destroy(child);
    }
    public void DiscardInvSlot2()
    {
        var child = inventorySlots[1].transform.GetChild(1).gameObject;

        inventorySlotOpen[1] = true;
        playerweight.weight = playerweight.weight - slotWeight[1];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[1] = 0;
        itemName[1] = "Empty";
        Destroy(child);
    }
    public void DiscardInvSlot3()
    {
        var child = inventorySlots[2].transform.GetChild(1).gameObject;

        inventorySlotOpen[2] = true;
        playerweight.weight = playerweight.weight - slotWeight[2];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[2] = 0;
        itemName[2] = "Empty";
        Destroy(child);
    }
    public void DiscardInvSlot4()
    {
        var child = inventorySlots[3].transform.GetChild(1).gameObject;

        inventorySlotOpen[3] = true;
        playerweight.weight = playerweight.weight - slotWeight[3];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[3] = 0;
        itemName[3] = "Empty";
        Destroy(child);
    }
    public void DiscardInvSlot5()
    {
        var child = inventorySlots[4].transform.GetChild(1).gameObject;

        inventorySlotOpen[4] = true;
        playerweight.weight = playerweight.weight - slotWeight[4];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[4] = 0;
        itemName[4] = "Empty";
        Destroy(child);
    }
    public void DiscardInvSlot6()
    {
        var child = inventorySlots[5].transform.GetChild(1).gameObject;

        inventorySlotOpen[5] = true;
        playerweight.weight = playerweight.weight - slotWeight[5];
        playerweight.carryWeight.text = "Carry Weight: " + playerweight.weight;
        slotWeight[5] = 0;
        itemName[5] = "Empty";
        Destroy(child);
    }
    private void Update()
    {
        for (var j = 0; j < inventorySlots.Length; j++)
        {
            if (inventorySlots[j].transform.childCount == 0)
            {
                inventorySlotOpen[j] = true;
            }
        }

        if (inventorySlotOpen[0] == false && inventorySlotOpen[1] == false && inventorySlotOpen[2] == false && inventorySlotOpen[3] == false && inventorySlotOpen[4] == false && inventorySlotOpen[5] == false)
        {
            inventoryFull = true;
            invFullUI.SetActive(true);
        }
        if (inventorySlotOpen[0] || inventorySlotOpen[1] || inventorySlotOpen[2] || inventorySlotOpen[3] || inventorySlotOpen[4] || inventorySlotOpen[5])
        {
            inventoryFull = false;
            invFullUI.SetActive(false);
        }
        
    }

   
    // Legacy code (For reference)
    //Dont try create a brand new inventory system at 4am it ends up looking like this (It works but its not pretty)
    /*
    public void AddItemToInventory(GameObject itemPrefab)
    {
        GameObject newItem = Instantiate(itemPrefab);


        if (inventorySlotOpen[0] == true)
        {

            newItem.transform.SetParent(inventorySlots[0].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[0] = newItem.name;
            inventorySlotOpen[0] = false;
        }
        else if (inventorySlotOpen[1] == true)
        {

            newItem.transform.SetParent(inventorySlots[1].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[1] = newItem.name;
            inventorySlotOpen[1] = false;
        }
        else if (inventorySlotOpen[2] == true)
        {

            newItem.transform.SetParent(inventorySlots[2].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[2] = newItem.name;
            inventorySlotOpen[2] = false;
        }
        else if (inventorySlotOpen[3] == true)
        {

            newItem.transform.SetParent(inventorySlots[3].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[3] = newItem.name;
            inventorySlotOpen[3] = false;
        }
        else if (inventorySlotOpen[4] == true)
        {

            newItem.transform.SetParent(inventorySlots[4].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[4] = newItem.name;
            inventorySlotOpen[4] = false;
        }
        else if (inventorySlotOpen[5] == true)
        {

            newItem.transform.SetParent(inventorySlots[5].transform);

            newItem.transform.localPosition = Vector3.zero;
            itemName[5] = newItem.name;
            inventorySlotOpen[5] = false;
        }
        if (inventorySlotOpen[5] == false)
        {
            inventoryFull = true;
        }
        else
        {
            inventoryFull = false;
        }
    }
    void Update()
    {
        if (inventorySlots[0].transform.childCount == 0)
        {
            inventorySlotOpen[0] = true;
        }
        if (inventorySlots[1].transform.childCount == 0)
        {
            inventorySlotOpen[1] = true;
        }
        if (inventorySlots[2].transform.childCount == 0)
        {
            inventorySlotOpen[2] = true;
        }
        if (inventorySlots[3].transform.childCount == 0)
        {
            inventorySlotOpen[3] = true;
        }
        if (inventorySlots[4].transform.childCount == 0)
        {
            inventorySlotOpen[4] = true;
        }
        if (inventorySlots[5].transform.childCount == 0)
        {
            inventorySlotOpen[5] = true;
        }
    }

}
    */


}
