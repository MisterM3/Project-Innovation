using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    [SerializeField] GameObject[] sadgeList;
    [SerializeField] IInventoryItem[] inventoryList;

    IInventoryItem selectedItem;
    



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
        inventoryList = new IInventoryItem[sadgeList.Length];
        for (int i = 0; i < sadgeList.Count(); i++)
        {
            if (sadgeList[i] == null)
            {
                inventoryList[i] = null;
                continue;
            }
            if (sadgeList[i].TryGetComponent<IInventoryItem>(out IInventoryItem item))
            {
                inventoryList[i] = item;
                continue;
            }

            Debug.LogError("TRIED TO ADD A NOT IINVENTORYITEM AT START AT INDEX: " + i);
        }
    }
    public bool TryAddItem(IInventoryItem item)
    {
        for(int i = 0; i < inventoryList.Count(); i++)
        {
            if (inventoryList[i] != null) continue;

            Debug.Log($"Added {item} to inventory");
            inventoryList[i] = item;
            return true;
        }

        Debug.LogError("List Full Can't Add");
        return false;
    }

    public bool TryRemoveItem(IInventoryItem item)
    {
        for (int i = 0; i < inventoryList.Count(); i++)
        {
            if (inventoryList[i] != item) continue;

            inventoryList[i] = null;
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

    public IInventoryItem Peek(int index)
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
