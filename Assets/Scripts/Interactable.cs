using UnityEngine;

// Represents the base class for all interactable objects in the scene
public abstract class Interactable : MonoBehaviour
{

    public enum InteractionType {
        Click,
        Hold
    }
    
    float holdTime;
    Transform playerTransform;
    Transform interactableTransform;

    public InteractionType interactionType;
    public float radius = 3f;

    public abstract string GetDescription();
    public abstract void Interact();

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;

    public float GetHoldTime() => holdTime;
    
    public bool isInRange()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform; // Maybe singleton later?
        interactableTransform = gameObject.transform;
        float distance = Vector2.Distance(interactableTransform.position, playerTransform.position);

        if(distance <= radius)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos are only visible in the scene view -> NOT visible IN-GAME (DEBUG Reasons)
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
