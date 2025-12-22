using UnityEngine;

public class SimpleChest : MonoBehaviour
{
    // משתנים למעקב אחרי מצב התיבה ורכיב התצוגה שלה
    private bool isOpen = false;
    private Renderer chestRenderer;

    // משתנים לקביעת החומרים (Materials) במצבים שונים
    public Material openMaterial;
    public Material closedMaterial;

    void Start()
    {
        // מציאת רכיב ה-Renderer שאחראי על המראה של האובייקט
        chestRenderer = GetComponent<Renderer>();

        // בדיקה שהרכיבים קיימים והגדרת המראה ההתחלתי לסגור
        if (chestRenderer != null && closedMaterial != null)
        {
            chestRenderer.material = closedMaterial;
        }
    }

    // פונקציה המופעלת כאשר השחקן לוחץ על מקש האינטראקציה (למשל E)
    public void Interact()
    {
        // שינוי המצב מבוליאני: אמת הופך לשקר ולהיפך
        isOpen = !isOpen; 

        if (chestRenderer != null)
        {
            if (isOpen)
            {
                // עדכון ויזואלי למצב פתוח
                chestRenderer.material = openMaterial;
                Debug.Log("Chest Opened");
            }
            else
            {
                chestRenderer.material = closedMaterial;
                Debug.Log("Chest Closed");
            }
        }
    }

    public string GetPrompt()
    {
        return isOpen ? "Press E to Close" : "Press E to Open";
    }
}
