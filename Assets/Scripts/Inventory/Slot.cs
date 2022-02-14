using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    /// <summary>
    /// Holds an itemType the number of items and the number of maxItems
    /// this has no logic so everything has to be done from the outside
    /// [Get/Set]
    /// ItemType
    /// Count
    /// MaxItems
    /// [Methods]
    /// void addItem(int count = 1)
    /// void removeItem(int count = 1) 
    /// </summary>

    Item item;
    int maxItems = 1;
    int count = 0;
    public Item ItemType { get => item; set => item = value; }
    public int Count { get => count; set => count = value; }
    public int MaxItems { get => maxItems; set => maxItems = value; }
    public Slot(int maxItems = 1)
    {
        item = null;
        this.maxItems = maxItems;
    }
    public void addItem(int count = 1)
    {
        // adds any number of items to the slot will also go over the max items
        this.count += count;
    }
    public void removeItem(int count = 1) 
    {
        // removes any number of items from the slot will also go negative 
        this.count -= count;
    }    
}
