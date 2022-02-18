using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] Item item1;// not needed
    [SerializeField] Item item2;// not needed
    public Item selectedItem;

    Item testItem;
    public Inventory inventory;
    [SerializeField] UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = transform.GetComponent<Inventory>();
        inventory.createEmptyInventory(8,10);

        testItem = Instantiate(item1);

        inventory.addItemAt(0, item1, 8);
        inventory.addItemAt(0, testItem, 1);
        inventory.addItemAt(3, item2, 15);
        inventory.addItemAt(4, item1, 3);

        /*
        Debug.Log(inventory.addItemAt(0, item2, 15));
        Debug.Log(inventory.getInventory[0].Count);
        Debug.Log(inventory.removeItemAt(0, 10));
        Debug.Log(inventory.getInventory[0].Count);
        */ 


       // uiInventory.setInventory(inventory);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // FOR DEBUG
        if (Input.GetKeyDown(KeyCode.X))
        {
            testItem.Select();
            if(testItem.isSelected)
                selectedItem = testItem;
            else
                selectedItem = null;                   
        }
    }
}
