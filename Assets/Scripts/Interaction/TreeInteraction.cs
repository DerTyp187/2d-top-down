using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Harvestable
{

    Inventory playerInv;

    [SerializeField]
    List<Item> drops = new List<Item>();

    private void Start()
    {
        playerInv = GameObject.Find("Player").GetComponent<Inventory>();
        toolType = ToolType.AXE;

    }



    public override string GetDescription()
    {
        if (isInRange())
            return "Baum muss weg";
        else  
            return "Tree is not in range";
    }
    public override void Interact()
    {
        // TODO
        // ADD DROPS TO INVENTORY
        // START ANIMATION
        // DURABILITY ON TOOL

        Debug.Log("Harvest BAUM");

        Destroy(gameObject);
    }
}