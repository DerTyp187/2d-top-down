using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Interactable
{
    public override string GetDescription() => "Baum muss schreien";
    public override void Interact()
    {
        if (isInRange())
            Debug.Log("AaaaaaaaaaAaAAaAaAAaAaAaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        else
            Debug.Log("Tree is not in range");
    }
}