using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Interactable
{
    public override string GetDescription() => "Baum muss schreie";
    public override void Interact()
    {
        if(isInRange())
            Debug.Log("AaaaaaaaaaAaAAaAaAAaAaAaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
    }
}

