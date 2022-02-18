using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
public class Item : ScriptableObject
{
    public new string name;
    public int id;
    public bool isStackable;
    public Sprite sprite;
}
