using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
