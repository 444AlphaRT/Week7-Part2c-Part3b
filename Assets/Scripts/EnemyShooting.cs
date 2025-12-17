using UnityEngine;
using System.Collections; // **חובה** עבור קורוטינות

public class EnemyShooting : MonoBehaviour
{
    // משתנים ציבוריים להגדרת התקיפה
    public float shootingRange = 10f; // מרחק מקסימלי לירי
    public int damageAmount = 10;      // כמות הנזק בכל פגיעה
    public float fireRate = 2f;        // יריות לשנייה (1 / fireRate = זמן בין יריות)
    public float lineDuration = 0.05f; // משך זמן הופעת הקו (כדי שייראה כהרף עין)
    private LineRenderer lineRenderer;

    // הפניה לטרנספורם של השחקן (אותו נמצא ב-Start)
    private Transform playerTarget;
    private float nextFireTime;

    void Start()
    {
        // מציאת השחקן
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTarget = player.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Check if it has the 'Player' tag.");
            enabled = false;
        }

        // 🌟 משיגים את רכיב ה-Line Renderer
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            // אם הרכיב לא נוסף ב-Inspector
            Debug.LogError("Missing Line Renderer component on Enemy! Please add it in the Inspector.");
        }
        else
        {
            lineRenderer.enabled = false; // מכבים אותו בהתחלה
        }
    }

    void Update()
    {
        if (playerTarget == null) return;

        // 1. בדיקת טווח: רק אם השחקן קרוב מספיק
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= shootingRange)
        {
            // 2. בדיקת קו ראייה וירי
            if (Time.time >= nextFireTime)
            {
                TryShootPlayer();
                nextFireTime = Time.time + 1f / fireRate; // הגדרת הזמן לירי הבא
            }
        }
    }

    private void TryShootPlayer()
    {
        // כיוון הירי
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            // בדיקה אם הפגיעה הייתה בשחקן
            HealthSystem targetHealth = hit.collider.GetComponent<HealthSystem>();

            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damageAmount);
                StartCoroutine(ShootLineVisual(hit.point));
            }
            else
            {
                // פגע במשהו אחר (כמו הרצפה או קיר)
                StartCoroutine(ShootLineVisual(hit.point));
            }
        }
        else
        {
            // לא פגע בכלום, מפעיל ויזואליזציה עד קצה הטווח
            StartCoroutine(ShootLineVisual(transform.position + direction * shootingRange));
        }

    }

    private IEnumerator ShootLineVisual(Vector3 endPosition)
    {
        if (lineRenderer == null) yield break; // יציאה אם אין LineRenderer

        // 1. הגדרת מיקום הקו
        lineRenderer.SetPosition(0, transform.position); // נקודת התחלה
        lineRenderer.SetPosition(1, endPosition);        // נקודת סיום

        // 2. הפעלת הקו
        lineRenderer.enabled = true;

        // 3. המתנה
        yield return new WaitForSeconds(lineDuration);

        // 4. כיבוי הקו
        lineRenderer.enabled = false;
    }
}