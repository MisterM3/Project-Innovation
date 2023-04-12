using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    [SerializeField] Sprite spriteInInventory;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inventory inventory = Inventory.Instance;

            if (inventory == null)
            {
                Debug.LogError("NO INVENTORY IN SCENE");
                return;
            }

            if (inventory.TryAddItem(this))
            {
                //DeActivate object
                this.gameObject.SetActive(false);
            }
            
        }
    }
}
