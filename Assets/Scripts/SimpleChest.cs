using UnityEngine;

public class SimpleChest : MonoBehaviour
{
    private bool isOpen = false;
    private Renderer chestRenderer;

    public Material openMaterial;
    public Material closedMaterial;

    void Start()
    {
        // Get the Renderer component to change visuals
        chestRenderer = GetComponent<Renderer>();

        if (chestRenderer != null && closedMaterial != null)
        {
            // Set initial material to closed state
            chestRenderer.material = closedMaterial;
        }
    }

    public void Interact()
    {
        // Toggle the open/closed state
        isOpen = !isOpen;

        if (chestRenderer != null)
        {
            if (isOpen)
            {
                chestRenderer.material = openMaterial;
                Debug.Log("Chest Opened!");
            }
            else
            {
                chestRenderer.material = closedMaterial;
                Debug.Log("Chest Closed.");
            }
        }
    }

    public string GetPrompt()
    {
        // Return instruction for the player
        return isOpen ? "Press E to Close" : "Press E to Open";
    }
}