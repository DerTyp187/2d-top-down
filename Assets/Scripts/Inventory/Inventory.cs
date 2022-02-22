using System;
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

    public Item testItemType;

    public static Action OnPlayerInventoryChanged;
    public static Action OnPlayerItemAdded;
    public static Action OnPlayerItemRemoved;

    [Header("Inventory")]
    [SerializeField]
    int numberOfSlots = 20;

    [SerializeField]
    int maxSpaceOfSlots = 10;

    [SerializeField]
    bool isPlayerInventory = true;

    [SerializeField]
    List<Slot> inventory = new List<Slot>();

    public List<Slot> GetInventory() => inventory;

    public void AddSlots(int _numberOfSlots)
    {
        for (int i = 0; i < _numberOfSlots; i++)
        {
            inventory.Add(new Slot());
        }
        if(isPlayerInventory)
            OnPlayerInventoryChanged?.Invoke();
    }
    Slot GetEmptySlot()
    {
        foreach (Slot slot in inventory)
        {
            if (slot.GetItem() == null)
                return slot;
        }
        return null;
    }
    Slot GetSlotByItem(Item item)
    {
        foreach (Slot slot in inventory)
        {
            if (slot.GetItem() != null)
            {
                if (slot.GetItem().id == item.id)
                    return slot;
            }

        }
        return null;
    }
    int GetRest(int count, Slot slot)
    {
        if (CountFitsInSlot(count, slot))
        {
            return 0;
        }
        else
        {
            return (count - (maxSpaceOfSlots - slot.GetCount()));
        }
    }
    bool CountFitsInSlot(int count, Slot slot)
    {
        int leftSize = maxSpaceOfSlots - slot.GetCount();
        if (leftSize > count) // left size > count
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool indexIsInRange(int index)
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


    public int Remove(Item itemType, int count, int invIndex = -1)
    {
        Slot slot = null;

        Item item = Instantiate(itemType);
        if (item == null)
            return -1;

        // Get Slot
        if (invIndex > -1)
        {
            if (indexIsInRange(invIndex))
                slot = inventory[invIndex];
        }
        else
        {
            slot = GetSlotByItem(item);
        }

        if (slot == null)
            return -1;

        // remove
        if (slot.GetItem() != null && slot.GetItem().id == item.id) // Wenn im Slot schon das gleiche item ist
        {
            int rest = 0;

            if (slot.GetCount() >= count)
            {
                slot.RemoveCount(count);
            }
            else
            {
                rest = count - slot.GetCount();
                slot.Clear();
            }

            if (isPlayerInventory)
            {
                OnPlayerInventoryChanged?.Invoke();
                OnPlayerItemRemoved?.Invoke();
            }
            
            return rest;
        }
        else
            return -1;
    }

    public int Add(Item itemType, int count, int invIndex = -1)
    {
        int rest = 0;
        Slot slot = null;
        
        Item item = Instantiate(itemType);
        if (item == null)
            return -1;

        // Get Slot
        if (invIndex > -1)
        {
            if(indexIsInRange(invIndex))
                slot = inventory[invIndex];
        }
        else
        {
            slot = GetSlotByItem(item);
            if (slot == null)
                slot = GetEmptySlot();
        }

        if (slot == null)
            return -1;

        // add
        if (slot.GetItem() != null && slot.GetItem().id == item.id) // Wenn im Slot schon das selbe item ist
        {
            if (CountFitsInSlot(count, slot))
            {
                slot.AddCount(count);
            }
            else
            {
                rest = GetRest(count, slot);
                slot.Set(item, maxSpaceOfSlots);
            }
        }
        else if (slot.GetItem() == null)
        {
            if (CountFitsInSlot(count, slot))
            {
                slot.Set(item, count);
            }
            else
            {
                rest = GetRest(count, slot);
                slot.Set(item, maxSpaceOfSlots);
            }
        }
        else
            return -1;

        if (isPlayerInventory)
        {
            OnPlayerInventoryChanged?.Invoke();
            OnPlayerItemAdded?.Invoke();
        }
       
        return rest;
    }


    void Start()
    {
        AddSlots(numberOfSlots);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(Add(testItemType, 8, 4));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(Remove(testItemType, 8, 4));
        }
    }
}
