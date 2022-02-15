using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Interactable
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
        if (isInRange())
            Debug.Log("AaaaaaaaaaAaAAaAaAAaAaAaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        else
            Debug.Log("Tree is not in range");
    }
}