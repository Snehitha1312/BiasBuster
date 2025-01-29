using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
         public void LoadScene()
    {
        SceneManager.LoadScene(1); // Load the scene by name
    }

}
