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
                successfulHit = true;
                HandleInteractionText(interactable);
            }            
        }

        if (!successfulHit)
        {
            interactionText.text = "";
        }

    }
    void HandleInteractionText(Interactable interactable)
    {
        interactionText.text = interactable.GetDescription();
        interactionText.transform.position = new Vector3(Input.mousePosition.x + interactionText.rectTransform.sizeDelta.x / 2 + 20, Input.mousePosition.y - 5, Input.mousePosition.z);

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
