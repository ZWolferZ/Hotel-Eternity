using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public GameObject inventorySlot1;
    public GameObject inventorySlot2;
    public GameObject inventorySlot3;
    public GameObject inventorySlot4;
    public GameObject inventorySlot5;
    public GameObject inventorySlot6;

    bool inventorySlot1Open = true;
    bool inventorySlot2Open = true;
    bool inventorySlot3Open = true;
    bool inventorySlot4Open = true;
    bool inventorySlot5Open = true;
    bool inventorySlot6Open = true;
   public bool inventoryFull = false;
   
    public string item1;
    public string item2;
    public string item3;
    public string item4;
    public string item5;
    public string item6;

  

    public void AddItemToInventory(GameObject itemPrefab)
    {
        GameObject newItem = Instantiate(itemPrefab);

        

        if (inventorySlot1Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot1.transform);
            
            newItem.transform.localPosition = Vector3.zero; 
            item1 = newItem.name;
            inventorySlot1Open = false;
        }
        else if (inventorySlot2Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot2.transform);
            
            newItem.transform.localPosition = Vector3.zero;
            item2 = newItem.name;
            inventorySlot2Open = false;
        }
        else if (inventorySlot3Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot3.transform);
            
            newItem.transform.localPosition = Vector3.zero;
            item3 = newItem.name;
            inventorySlot3Open = false;
        }
        else if (inventorySlot4Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot4.transform);
            
            newItem.transform.localPosition = Vector3.zero;
            item4 = newItem.name;
            inventorySlot4Open = false;
        }
        else if (inventorySlot5Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot5.transform);
            
            newItem.transform.localPosition = Vector3.zero;
            item5 = newItem.name;
            inventorySlot5Open = false;
        }
        else if (inventorySlot6Open == true)
        {
            
            newItem.transform.SetParent(inventorySlot6.transform);
            item6 = newItem.name;
            newItem.transform.localPosition = Vector3.zero;
            
            inventorySlot6Open = false;
        }
        if (inventorySlot6Open == false)
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
        if (inventorySlot1.transform.childCount == 0)
        {
            inventorySlot1Open = true;
        }
        if (inventorySlot2.transform.childCount == 0)
        {
            inventorySlot2Open = true;
        }
        if (inventorySlot3.transform.childCount == 0)
        {
            inventorySlot3Open = true;
        }
        if (inventorySlot4.transform.childCount == 0)
        {
            inventorySlot4Open = true;
        }
        if (inventorySlot5.transform.childCount == 0)
        {
            inventorySlot5Open = true;
        }
        if (inventorySlot6.transform.childCount == 0)
        {
            inventorySlot6Open = true;
        }
    }

}
