using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    
    Item item;
    int maxItems;
    int count;
    public Slot(int maxItems)
    {
        item = null;
        this.maxItems = maxItems;
        count = 0;

    }
    public bool removeItem() 
    {
        if (count > 0)
        {
            count--;
            if (count == 0) 
            {
                item = null;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool addItem(int count = 1)
    {
        this.count += count;
        return true;

    }
    public Item ItemType { get => item; set => item = value; }
    public int Count { get => count; set => count = value; }
    public int MaxItems { get => maxItems; set => maxItems = value; }
}
