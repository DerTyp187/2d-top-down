using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Slot
{
    [SerializeField]
    Item item = null;

    [SerializeField]
    int count = 0;

    public Item GetItem() => item;

    public int GetCount() => count;
   
    public void AddCount(int value) => count += value;

    public void SetCount(int newCount)
    {
        count = newCount;
        if (count <= 0)
            Clear();
    }

    public void RemoveCount(int value)
    {
        count -= value; 
        if (count <= 0)
            Clear();
    }
    public void ResetCount() => count = 0;

    public void Clear()
    {
        item = null;
        count = 0;
    }

    public void Set(Item _item, int _count = 1)
    {
        item = _item;
        count = _count;
    }
}
