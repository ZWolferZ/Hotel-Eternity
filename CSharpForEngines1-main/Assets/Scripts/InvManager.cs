using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public GameObject[] inventorySlots;

    public bool[] inventorySlotOpen;
    public string[] itemName;
    public bool inventoryFull = false;
    bool found = false;


    public void AddItemToInventory(GameObject itemPrefab)
    {
        GameObject newItem = Instantiate(itemPrefab);



        /*
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            for (int j = 0; j < itemName.Length; j++)
            {
                while (found == false)
                {
                    if (inventorySlotOpen[i] == true)
                    {

                        newItem.transform.SetParent(inventorySlots[i].transform);

                        newItem.transform.localPosition = Vector3.zero;
                        itemName[j] = newItem.name;
                        found = true;
                        inventoryFull = false;
                        inventorySlotOpen[i] = false;
                    }
                    if (inventorySlotOpen[i] == false)
                    {
                        inventoryFull = true;
                    }
                }
            }

          found = false;
        }
    }
}
        */
        
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
        