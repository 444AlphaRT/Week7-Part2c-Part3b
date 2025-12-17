using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // משתנים ציבוריים להגדרה ב-Inspector
    public int maxHealth = 100;

    // משתנה פרטי למעקב אחרי מצב החיים הנוכחי
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health Initialized: " + currentHealth);
    }

    // פונקציה ציבורית שאויבים יכולים לקרוא לה כדי לפגוע בשחקן
    public void TakeDamage(int damageAmount)
    {
        if (currentHealth <= 0) return; // אם כבר מת, אין צורך להמשיך

        currentHealth -= damageAmount;

        Debug.Log("Player took " + damageAmount + " damage. Remaining Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("GAME OVER! Player has died.");

        // כאן היינו מכניסים קוד לסיום המשחק (לדוגמה, עצירת זמן, טעינת מסך הפסד)
        // Time.timeScale = 0f; 

        // נסיר את השחקן מהסצנה לצורך הדגמה
        Destroy(gameObject);
    }
}