using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Harvestable
{
    
    public override string GetDescription()
    {
        if (isInRange())
            return "Baum muss schreien";
        else  
            return "Tree is not in range";
    }
    public override void Interact()
    {
        Debug.Log("Harvest BAUM");
    }
}