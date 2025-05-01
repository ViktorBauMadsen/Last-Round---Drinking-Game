using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SwitchToQoute : MonoBehaviour
{
	public float DelaySeconds = 2f;

	[Header("Image component here")]
	public Image beerLiquidImage;

	[Header("''Empty beer’' sprite here")]
	public Sprite emptySprite;

	void Update()
	{
		if (beerLiquidImage.sprite == emptySprite)
		{
			StartCoroutine(LoadNextSceneAfterDelay());
		}
	}

	IEnumerator LoadNextSceneAfterDelay()
	{
		yield return new WaitForSeconds(DelaySeconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
