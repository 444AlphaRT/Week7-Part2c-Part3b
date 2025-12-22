using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float shootingRange = 10f;
    public int damageAmount = 10;
    public float fireRate = 1f;
    public float lineDuration = 0.05f;

    private LineRenderer lineRenderer;
    private Transform playerTarget;
    private float nextFireTime;

    void Start()
    {
        // Find player by tag
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) playerTarget = player.transform;

        // Setup the LineRenderer for shot visualization
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null) lineRenderer.enabled = false;
    }

    void Update()
    {
        if (playerTarget == null) return;

        float distance = Vector3.Distance(transform.position, playerTarget.position);

        // Check range and cooldown
        if (distance <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        // Perform Raycast
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            HealthSystem health = hit.collider.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }

            // Draw line to hit point
            StartCoroutine(ShowLine(hit.point));
        }
        else
        {
            // Draw line to max range if nothing was hit
            StartCoroutine(ShowLine(transform.position + direction * shootingRange));
        }
    }

    IEnumerator ShowLine(Vector3 targetPos)
    {
        if (lineRenderer == null) yield break;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetPos);

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(lineDuration);
        lineRenderer.enabled = false;
    }
}