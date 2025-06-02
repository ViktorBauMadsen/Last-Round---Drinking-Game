using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    void Start()
    {
        // Automatically load the next scene when this object is enabled
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
