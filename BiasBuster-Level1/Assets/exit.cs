using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    void Startt()
    {
    }

    void Updatee()
    {
    }

    public void GoToNext()
    {
        // Load Scene 1 by name or index
        SceneManager.LoadScene(0); // Assuming Scene 1 is at index 0 in Build Settings

    }
}