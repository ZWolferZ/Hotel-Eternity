using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUPDOWN : MonoBehaviour
{

    public GameObject inventory;

    private void Awake()
    {
        if (inventory == null)
        {
            Debug.Log("No Inventory Assigned");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 inventoryPos = inventory.transform.position;
            inventory.transform.position = new Vector3(inventoryPos.x, inventoryPos.y + 200, inventoryPos.z);
           
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Vector3 inventoryPos = inventory.transform.position;
            inventory.transform.position = new Vector3(inventoryPos.x, inventoryPos.y - 200, inventoryPos.z);

        }

    }


}
