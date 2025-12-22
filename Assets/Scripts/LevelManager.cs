using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        // move to part 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("sence-part 2c");
        }

        // move to part 3
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("sence-part 3b");
        }
    }
}