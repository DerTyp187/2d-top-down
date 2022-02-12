using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// -------------------------------------------------------------------------------///
    /// 
    /// Inventory holds a list of Slots where Items can be added.
    ///
    ///[IMPORTANT]
    /// !!createEmptyInventory(int numberOfSlots, int maxSpaceOfSlots) : Has to be called after the Inventory has been initialized!!
    ///
    ///[Methods]
    /// getInventory() : Gets the list of Slots.
    /// addItemAt(int index, Item itemType,int count) : Adds a number (count) of items of type itemType (itemType) to an item slot(index).
    /// removeItemAt(int index, int count) : Removes a number of items (count)  from a specific slot (index).
    /// addInventorySlots(int numberOfSlots, int maxSpaceOfSlots = 10)
    /// 
    /// -------------------------------------------------------------------------------///
    /// </summary>



    List<Slot> inventory = new List<Slot>();

    public List<Slot> getInventory { get => inventory;}
    public void createEmptyInventory(int numberOfSlots, int maxSpaceOfSlots = 10) 
    {
        // Initializes the inventory with a specific number of slots and slotsize.
        // !!!Has to be called bevore adding any items!!!
        // Example createEmptyInventory(5, 10) : 5 Slots with space for 10 items each
        inventory = new List<Slot>();
        for (int i = 0; i < numberOfSlots; i++)
        {
            inventory.Add(new Slot(maxSpaceOfSlots));
        }
        
    }
    public void addInventorySlots(int numberOfSlots, int maxSpaceOfSlots = 10)
    {
        // Adds a specific number of slots and slotsize to the inventory.
        // Example addInventorySlots(5, 10) : Adds 5 Slots with space for 10 items each
        for (int i = 0; i < numberOfSlots; i++)
        {
            inventory.Add(new Slot(maxSpaceOfSlots));
        }

    }
    public int addItemAt(int index, Item itemType,int count) 
    {
        // Adds a number (count = 7) of items of type itemType (itemType = Stone) to an item slot(index = 3).
        //Returns the number of items that could not be added because of unsufficent space in the specefied slot
        //or Return -1 if the index is out of bound or the item slot is already filled with a different itemType.
        //
        // Example inventory.addItemAt(3,Stone,7);

        if (indexIsInRange(index) && (inventory[index].ItemType == null || inventory[index].ItemType.id == itemType.id))
        {
            if (inventory[index].ItemType == null) 
            {
                inventory[index].ItemType = Instantiate(itemType); // Set the itemType if the slot was empty.
            }

            if (inventory[index].MaxItems == inventory[index].Count) 
            {
                return count; // Can't add any items if the slot is full.
            }
            else if (inventory[index].MaxItems >= inventory[index].Count + count)
            {
                inventory[index].addItem(count); // Adds all items if there is enought space.
                return 0;
            } else 
            {
                int rest = count - inventory[index].MaxItems - inventory[index].Count;
                inventory[index].addItem(inventory[index].MaxItems - inventory[index].Count); // Adds the number of items until the slot is full and returns the number of items that didn't fit.
                return rest;
            }
        }
        else 
        {
            
            return -1;//Wrong item or index not in range.
        }
    }
    public int removeItemAt(int index, int count)
    {
        // Removes a number of items (count = 5)  from a specific slot (index = 4).
        // Example inventory.removeItemAt(4,5)
        if (indexIsInRange(index))
        {
            if (inventory[index].ItemType == null)
            {
                return count;// Can't remove any items if the slot is empty.
            }
            else if (inventory[index].Count > count)
            {
                inventory[index].removeItem(count);// Removes the number of items if there are more or equal items in the slot.
                return 0;
            }
            else if (inventory[index].Count <= count)
            {
                int rest = count - inventory[index].Count;
                inventory[index].Count = 0; // Removes all the items from the slot  and returns the number of items that could not be removed.
                inventory[index].ItemType = null; // When the slot is empty the itemType can also be removed.
                return rest;
            }
            else 
            {
                return -1; // Something went wrong (you should never end up in here).
            }
            
        }
        else
        {
            return -1;//Index not in range.
        }
    }
    private bool indexIsInRange(int index)
    {
        // Returns true if a given index is in the bounds of the inventory.
        // Example (maxSize = 10) index = -10 : false , index =  100: false, index = 7 : true 

        if (index < inventory.Count && index >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
