using UnityEditor.SearchService;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{
  public void LoadNextScene(int NextScene)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
