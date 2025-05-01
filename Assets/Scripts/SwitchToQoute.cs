using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToQoute : MonoBehaviour
{
    public GameObject EmptyBeer_0_Sprite;

    public void Update()
    {
        if(EmptyBeer_0_Sprite.activeInHierarchy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

    }
}
