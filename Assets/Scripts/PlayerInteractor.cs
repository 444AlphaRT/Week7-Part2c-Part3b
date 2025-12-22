using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
<<<<<<< HEAD
    // Reference to the chest object currently within range
    private SimpleChest currentInteractable = null;
    public KeyCode interactionKey = KeyCode.E;

    // Triggered when the player's collider enters a trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Attempt to find the SimpleChest component on the object
=======
    // îùúðä ùéçæé÷ äôðéä ìàåáéé÷è ä-SimpleChest äðåëçé áèååç
    private SimpleChest currentInteractable = null;
    public KeyCode interactionKey = KeyCode.E;

    // ð÷øà ëàùø äùç÷ï (ä÷åìééãø ùìå) ðëðñ ì-Trigger
    void OnTriggerEnter(Collider other)
    {
        // îðñä ìîöåà àú øëéá SimpleChest òì äàåáéé÷è
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        if (interactable != null)
        {
            currentInteractable = interactable;
<<<<<<< HEAD
            // Display interaction prompt in the console
=======
            // äöâ àú ääåãòä äøìååðèéú á÷åðñåì
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
            Debug.Log("Entered Interaction Zone. " + interactable.GetPrompt());
        }
    }

<<<<<<< HEAD
    // Triggered when the player's collider exits a trigger zone
=======
    // ð÷øà ëàùø äùç÷ï éåöà îä-Trigger
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
    void OnTriggerExit(Collider other)
    {
        SimpleChest interactable = other.GetComponent<SimpleChest>();

<<<<<<< HEAD
        // Ensure we are clearing the reference to the correct object
=======
        // îååãà ùàðçðå éåöàéí îàåúå àåáéé÷è àéúå äúëååðå ì÷ééí àéðèøà÷öéä
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Exited Interaction Zone.");
        }
    }

    void Update()
    {
<<<<<<< HEAD
        // If an interactable object is available and the player presses the key
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentInteractable.Interact();
            // Display the updated prompt after interaction
=======
        // àí éù àåáéé÷è àéðèøà÷èéáé æîéï åäùç÷ï ìçõ òì î÷ù äàéðèøà÷öéä
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentInteractable.Interact();
            // äöâ àú ä-prompt äçãù ìàçø äôòåìä
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
            Debug.Log(currentInteractable.GetPrompt());
        }
    }
}
