using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]public List<Slot> inventory = new List<Slot>();
    [SerializeField] int maxSize;

    public List<Slot> getInventory { get => inventory; set => inventory = value; }
    public void createEmptyInventory(int size) 
    {
        inventory = new List<Slot>();
        for (int i = 0; i < size; i++)
        {
            inventory.Add(new Slot(10));
        }
        
    }
    bool indexIsInRange(int index) 
    {
        if (index < maxSize && index >= 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public int addItemAt(int index, Item itemType,int count) 
    {

        if (indexIsInRange(index) && (inventory[index].ItemType == null || inventory[index].ItemType.id == itemType.id))
        {
            if (inventory[index].ItemType == null) 
            {
                inventory[index].ItemType = Instantiate(itemType);
            }

            if (inventory[index].MaxItems == inventory[index].Count) 
            {
                return count;
            }
            else if (inventory[index].MaxItems >= inventory[index].Count + count)
            {
                inventory[index].addItem(count);
                return 0;
            } else 
            {
                int rest = count - inventory[index].MaxItems - inventory[index].Count;
                inventory[index].addItem(inventory[index].MaxItems - inventory[index].Count);
                return rest;
            }
        }
        else 
        {
            //Wrong item or index not in range
            return -1;
        }
    }
    public int removeItemAt(int index, int count)
    {

        if (inventory[index].ItemType != null && indexIsInRange(index))
        {
            for (int i = 0; i < count; i++)
            {
                if (!inventory[index].removeItem())
                {
                    return count - i;
                }
            }
            return 0;
        }
        else
        {
            //index not in range
            return -1;
        }
    }
    /*
    Item findItem(Item itemType) 
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    bool removeItem(Item item,int count = 1) 
    {

        return true;
    }
    bool removeItemAt(int index,int count = -1)
    {
        
    }
    Item getItemAt(int index) 
    {
        if (index < maxSize && index >= 0)
        {
            return items[index];
        }
        else 
        {
            return null;
        }
        
    }
    */
}
