using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Reference to the chest object currently within range
    private SimpleChest currentInteractable = null;
    public KeyCode interactionKey = KeyCode.E;

    // Triggered when the player's collider enters a trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Attempt to find the SimpleChest component on the object
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        if (interactable != null)
        {
            currentInteractable = interactable;
            // Display interaction prompt in the console
            Debug.Log("Entered Interaction Zone. " + interactable.GetPrompt());
        }
    }

    // Triggered when the player's collider exits a trigger zone
    void OnTriggerExit(Collider other)
    {
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        // Ensure we are clearing the reference to the correct object
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Exited Interaction Zone.");
        }
    }

    void Update()
    {
        // If an interactable object is available and the player presses the key
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentInteractable.Interact();
            // Display the updated prompt after interaction
            Debug.Log(currentInteractable.GetPrompt());
        }
    }
}