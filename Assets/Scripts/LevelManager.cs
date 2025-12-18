using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        // לחיצה על 1 מעבירה לחלק הראשון
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("sence-part 2c");
        }

        // לחיצה על 2 מעבירה לחלק השני
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("sence-part 3b");
        }
    }
}