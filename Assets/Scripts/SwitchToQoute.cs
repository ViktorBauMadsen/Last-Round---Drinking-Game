using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SwitchToQoute : MonoBehaviour
{
	public float DelaySeconds = 2f;		//creating a float that determines how long x should be
										//delayed for (to get rid of "magic numbers")

	[Header("Image component here")]	//creating a name for what image goes here
	public Image beerLiquidImage;		//creates an image called "beerLiquidImage"

	[Header("''Empty beer’' sprite here")]  //creating a name for what sprite goes here. It is a sprite
											//because the file in the game we want to check for is a sprite
	public Sprite emptySprite;          //creates a sprite called "emptySprite"

    void Update()						//you know what "void Update" means
	{
		if (beerLiquidImage.sprite == emptySprite)  //we say that; if the sprite that is active in "beerLiquidImage" equals/is
													//the same one that is defined in "emptySprite", start the following code
		{
			StartCoroutine(LoadNextSceneAfterDelay());	//starting a coroutine called "LoadNextSceneAfterDelay"
		}
	}

	IEnumerator LoadNextSceneAfterDelay()   //an ENUM (coroutine) called "LoadNextSceneAfterDelay"
	{
		yield return new WaitForSeconds(DelaySeconds);	//yield means wait, yield return means wait with returning x. Here "x" is defined
														//as new WaitForSeconds(DelaySeconds), where DelaySeconds was defined at the top
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //it just loads the next scene in the build
	}
}
