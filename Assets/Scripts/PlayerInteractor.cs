using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // îùúðä ùéçæé÷ äôðéä ìàåáéé÷è ä-SimpleChest äðåëçé áèååç
    private SimpleChest currentInteractable = null;
    public KeyCode interactionKey = KeyCode.E;

    // ð÷øà ëàùø äùç÷ï (ä÷åìééãø ùìå) ðëðñ ì-Trigger
    void OnTriggerEnter(Collider other)
    {
        // îðñä ìîöåà àú øëéá SimpleChest òì äàåáéé÷è
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        if (interactable != null)
        {
            currentInteractable = interactable;
            // äöâ àú ääåãòä äøìååðèéú á÷åðñåì
            Debug.Log("Entered Interaction Zone. " + interactable.GetPrompt());
        }
    }

    // ð÷øà ëàùø äùç÷ï éåöà îä-Trigger
    void OnTriggerExit(Collider other)
    {
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        // îååãà ùàðçðå éåöàéí îàåúå àåáéé÷è àéúå äúëååðå ì÷ééí àéðèøà÷öéä
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Exited Interaction Zone.");
        }
    }

    void Update()
    {
        // àí éù àåáéé÷è àéðèøà÷èéáé æîéï åäùç÷ï ìçõ òì î÷ù äàéðèøà÷öéä
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentInteractable.Interact();
            // äöâ àú ä-prompt äçãù ìàçø äôòåìä
            Debug.Log(currentInteractable.GetPrompt());
        }
    }
}
