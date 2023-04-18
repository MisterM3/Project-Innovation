using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisuals : MonoBehaviour
{

    [SerializeField] GameObject boxInventoryprefab;
    [SerializeField] Inventory inventory;
    [SerializeField] Transform parentPanel;

    // Start is called before the first frame update
    void Start()
    {
        
        inventory= GetComponentInParent<Inventory>();
        if (inventory == null)
        {
            Debug.LogError("No Inventory scipt on parent of:" + gameObject.name);
            return;
        }

        for (int i = 0; i < inventory.GetInventorySize(); i++)
        {
            GameObject boxInventory = Instantiate(boxInventoryprefab, parentPanel);
            boxInventory.GetComponent<InventoryUIButton>().Setup(i, inventory);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
