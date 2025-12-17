using UnityEngine;

public class SimpleChest : MonoBehaviour
{
    // משתנים פרטיים לניהול מצב ורנדרר
    private bool isOpen = false;
    private Renderer chestRenderer;
    public Material openMaterial;
    public Material closedMaterial;

    void Start()
    {
        // קבלת רכיב ה-Renderer שמנהל את מראה האובייקט
        chestRenderer = GetComponent<Renderer>();
        if (chestRenderer != null && closedMaterial != null)
        {
            // הגדרת המראה ההתחלתי (סגור)
            chestRenderer.material = closedMaterial;
        }
    }

    // פונקציה שמבצעת את האינטראקציה (נקראת על ידי השחקן)
    public void Interact()
    {
        isOpen = !isOpen; // הופך את המצב

        if (chestRenderer != null)
        {
            if (isOpen)
            {
                chestRenderer.material = openMaterial;
                Debug.Log("Chest Opened! Found some loot.");
            }
            else
            {
                chestRenderer.material = closedMaterial;
                Debug.Log("Chest Closed.");
            }
        }
    }

    // פונקציה שמחזירה את הטקסט שיוצג לשחקן
    public string GetPrompt()
    {
        return isOpen ? "Press E to Close Chest" : "Press E to Open Chest";
    }
}