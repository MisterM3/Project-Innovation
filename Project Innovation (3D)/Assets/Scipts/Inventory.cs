using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    [SerializeField] GameObject[] sadgeList;
    [SerializeField] PickupableObject[] inventoryList;

    PickupableObject selectedItem;

    EventHandler<int> onItemAdded;
    EventHandler<int> onItemRemoved;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Already a Inventory in scene, destroying: " + gameObject.name);
            Destroy(this);
            return;
        }

        Instance = this;

        SetupInventory();


    }

    private void SetupInventory()
    {
        inventoryList = new PickupableObject[sadgeList.Length];
        for (int i = 0; i < sadgeList.Count(); i++)
        {
            if (sadgeList[i] == null)
            {
                inventoryList[i] = null;
                continue;
            }
            if (sadgeList[i].TryGetComponent<PickupableObject>(out PickupableObject item))
            {
                inventoryList[i] = item;
                continue;
            }

            Debug.LogError("TRIED TO ADD A NOT IINVENTORYITEM AT START AT INDEX: " + i);
        }
    }
    public bool TryAddItem(PickupableObject item)
    {
        for(int i = 0; i < inventoryList.Count(); i++)
        {
            if (inventoryList[i] != null) continue;

            Debug.Log($"Added {item} to inventory");
            inventoryList[i] = item;
            onItemAdded?.Invoke(this, i);
            return true;
        }

        Debug.LogError("List Full Can't Add");
        return false;
    }

    public bool TryRemoveItem(PickupableObject item)
    {
        for (int i = 0; i < inventoryList.Count(); i++)
        {
            if (inventoryList[i] != item) continue;

            inventoryList[i] = null;
            onItemRemoved?.Invoke(this, i);
            return true;
        }

        return false;
    }

    public bool TryRemoveItem(int index) 
    {
        if (inventoryList[index] == null) return false;

        inventoryList[index] = null;
        return true;
    }

    public PickupableObject Peek(int index)
    {
        return inventoryList[index];
    }

    public int GetInventorySize()
    {
        return inventoryList.Length;
    }

    public void SelectItem(int index)
    {
        selectedItem = inventoryList[index];
        Debug.Log(selectedItem);
    }


}
