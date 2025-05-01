using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchToQoute : MonoBehaviour
{
	[Header("Drag your Image component here")]
	public Image beerLiquidImage;   // or SpriteRenderer for world‐space sprites

	[Header("Drag your ‘Empty beer’ sprite asset here")]
	public Sprite emptySprite;

	bool hasSwitched = false;      // so we only load once

	void Update()
	{
		// safety checks
		if (hasSwitched || beerLiquidImage == null || emptySprite == null)
			return;

		// compare the currently showing sprite to your empty one
		if (beerLiquidImage.sprite == emptySprite)
		{
			hasSwitched = true;
			SceneManager.LoadScene(
			  SceneManager.GetActiveScene().buildIndex + 1
			);
		}
	}
}
