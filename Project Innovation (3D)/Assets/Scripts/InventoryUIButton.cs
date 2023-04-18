using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIButton : MonoBehaviour
{
    int index = 0;
    Inventory inventory;

    Image image;
    Sprite sprite;

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

    public void AddItem()
    {
        image.sprite = sprite;
    }
    public void RemoveItem()
    {
        image.sprite = null;
    }
}
