using UnityEngine;
using UnityEngine.SceneManagement;

public class done : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void GoTonextScene()
    {
        // Check if there is a previous scene in the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
        {
            // Load the previous scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No previous scene exists.");
        }
    }
}