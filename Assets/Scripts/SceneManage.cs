using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    // Loads a scene based on the given scene name.
    public void LoadScene(string scene_name)
    {
        // Use Unity's SceneManager to load the scene with the specified name
        SceneManager.LoadScene(scene_name);
    }
}
