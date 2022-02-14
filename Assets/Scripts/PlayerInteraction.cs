using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public TMPro.TextMeshProUGUI interactionText;

    void Update()
    {
        bool successfulHit = false;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider != null)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

            if(interactable != null)
            {
                // Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }            
        }

        if (!successfulHit)
        {
            interactionText.text = "";
        }

    }

    void HandleInteractionText() // interaction text has to follow mouse cursor
    {
        
    }

    void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetButtonDown("Interact"))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetButton("Interact"))
                {
                    interactable.IncreaseHoldTime();
                    
                    if(interactable.GetHoldTime() > 1f)
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                break;
            default:
                throw new System.Exception("Unsupported type of interactable");
        }
    }
}
