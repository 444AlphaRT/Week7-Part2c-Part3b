using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // משתנה שיחזיק הפניה לאובייקט ה-SimpleChest הנוכחי בטווח
    private SimpleChest currentInteractable = null;
    public KeyCode interactionKey = KeyCode.E;

    // נקרא כאשר השחקן (הקוליידר שלו) נכנס ל-Trigger
    void OnTriggerEnter(Collider other)
    {
        // מנסה למצוא את רכיב SimpleChest על האובייקט
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        if (interactable != null)
        {
            currentInteractable = interactable;
            // הצג את ההודעה הרלוונטית בקונסול
            Debug.Log("Entered Interaction Zone. " + interactable.GetPrompt());
        }
    }

    // נקרא כאשר השחקן יוצא מה-Trigger
    void OnTriggerExit(Collider other)
    {
        SimpleChest interactable = other.GetComponent<SimpleChest>();

        // מוודא שאנחנו יוצאים מאותו אובייקט איתו התכוונו לקיים אינטראקציה
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            Debug.Log("Exited Interaction Zone.");
        }
    }

    void Update()
    {
        // אם יש אובייקט אינטראקטיבי זמין והשחקן לחץ על מקש האינטראקציה
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentInteractable.Interact();
            // הצג את ה-prompt החדש לאחר הפעולה
            Debug.Log(currentInteractable.GetPrompt());
        }
    }
}