using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    int index = 0;
    Inventory inventory;

    public void SelectItemAtSpot()
    {
        if (inventory == null)
        {
            Debug.LogError(gameObject.name + " Has no inventory");
            return;
        }

        inventory.SelectItem(index);
    }

    public void Setup(int index, Inventory inventory)
    {
        this.index = index;
        this.inventory = inventory;
    }
}
