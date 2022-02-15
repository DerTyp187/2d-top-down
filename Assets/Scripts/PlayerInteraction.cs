using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI interactionText;

    [SerializeField]
    Image interactionProgressImg;

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
                HandleInteractionProgress(interactable);
            }            
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            interactionProgressImg.fillAmount = 0;
        }

    }

    void HandleInteractionProgress(Interactable interactable)
    {
        interactionProgressImg.fillAmount = interactable.GetHoldTime() / interactable.GetHoldDuration();
    }
    
    void HandleInteractionText(Interactable interactable)
    {
        interactionText.text = interactable.GetDescription();
        interactionText.transform.position = new Vector3(Input.mousePosition.x + interactionText.rectTransform.sizeDelta.x / 2 + 20, Input.mousePosition.y - 5, Input.mousePosition.z);
    }

    /// <summary>
    /// <c>HandleInteraction</c> <strong>handles the player interaction based on the Interactable.InteractionType.</strong>
    /// </summary>
    /// <param name="interactable"></param>
    void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetButtonDown("Interact") && interactable.isInRange())
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetButton("Interact") && interactable.isInRange())
                {
                    interactable.IncreaseHoldTime();
                    
                    if(interactable.GetHoldTime() > interactable.GetHoldDuration())
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
            case Interactable.InteractionType.Harvest:
                Harvestable harvestable = interactable.GetComponent<Harvestable>();

                if (Input.GetButton("Interact") && interactable.isInRange())
                {
                    harvestable.IncreaseHarvestTime();

                    if (harvestable.GetHarvestTime() >= harvestable.GetHarvestDuration())
                    {
                        harvestable.Interact();
                    }
                }
                break;
            default:
                throw new System.Exception("Unsupported type of interactable");
        }
    }
}
