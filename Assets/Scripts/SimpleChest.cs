using UnityEngine;

public class SimpleChest : MonoBehaviour
{
<<<<<<< HEAD
    private bool isOpen = false;
    private Renderer chestRenderer;

=======
    // משתנים למעקב אחרי מצב התיבה ורכיב התצוגה שלה
    private bool isOpen = false;
    private Renderer chestRenderer;

    // משתנים לקביעת החומרים (Materials) במצבים שונים
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
    public Material openMaterial;
    public Material closedMaterial;

    void Start()
    {
<<<<<<< HEAD
        // Get the Renderer component to change visuals
        chestRenderer = GetComponent<Renderer>();

        if (chestRenderer != null && closedMaterial != null)
        {
            // Set initial material to closed state
=======
        // מציאת רכיב ה-Renderer שאחראי על המראה של האובייקט
        chestRenderer = GetComponent<Renderer>();

        // בדיקה שהרכיבים קיימים והגדרת המראה ההתחלתי לסגור
        if (chestRenderer != null && closedMaterial != null)
        {
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
            chestRenderer.material = closedMaterial;
        }
    }

<<<<<<< HEAD
    public void Interact()
    {
        // Toggle the open/closed state
        isOpen = !isOpen;
=======
    // פונקציה המופעלת כאשר השחקן לוחץ על מקש האינטראקציה 
    public void Interact()
    {
        // שינוי המצב מבוליאני: אמת הופך לשקר ולהיפך
        isOpen = !isOpen; 
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040

        if (chestRenderer != null)
        {
            if (isOpen)
            {
                // עדכון ויזואלי למצב פתוח
                chestRenderer.material = openMaterial;
<<<<<<< HEAD
                Debug.Log("Chest Opened!");
=======
                Debug.Log("Chest Opened");
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
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
<<<<<<< HEAD
        // Return instruction for the player
=======
>>>>>>> 30557aa69e5af150de0bfff82140900144dbd040
        return isOpen ? "Press E to Close" : "Press E to Open";
    }
}
