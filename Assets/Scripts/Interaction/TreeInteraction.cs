using UnityEngine;

public class TreeInteraction : Harvestable
{

    private void Start()
    {
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
        Debug.Log("Harvest BAUM");
    }
}