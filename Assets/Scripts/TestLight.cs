using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TestLight : Interactable
{
    [Header("Test Light Properties")]
    [SerializeField] Color color;
    [SerializeField] Light2D globalLight;
    public override string GetDescription()
    {
        if (isInRange())
            return "Turn Light " + gameObject.name;
        else
            return "Light switch not in range";
    }
    public override void Interact()
    {
        globalLight.color = color;
        Debug.Log("Color set to " + gameObject.name);
       
    }
}
