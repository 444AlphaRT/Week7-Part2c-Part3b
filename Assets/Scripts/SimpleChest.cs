using UnityEngine;

public class SimpleChest : MonoBehaviour
{
    // îùúðéí ôøèééí ìðéäåì îöá åøðãøø
    private bool isOpen = false;
    private Renderer chestRenderer;
    public Material openMaterial;
    public Material closedMaterial;

    void Start()
    {
        // ÷áìú øëéá ä-Renderer ùîðäì àú îøàä äàåáéé÷è
        chestRenderer = GetComponent<Renderer>();
        if (chestRenderer != null && closedMaterial != null)
        {
            // äâãøú äîøàä ääúçìúé (ñâåø)
            chestRenderer.material = closedMaterial;
        }
    }

    // ôåð÷öéä ùîáöòú àú äàéðèøà÷öéä (ð÷øàú òì éãé äùç÷ï)
    public void Interact()
    {
        isOpen = !isOpen; // äåôê àú äîöá

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

    // ôåð÷öéä ùîçæéøä àú äè÷ñè ùéåöâ ìùç÷ï
    public string GetPrompt()
    {
        return isOpen ? "Press E to Close Chest" : "Press E to Open Chest";
    }
}
