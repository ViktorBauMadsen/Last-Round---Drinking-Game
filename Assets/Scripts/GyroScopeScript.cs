using UnityEngine;
using UnityEngine.UI;

public class GyroDrinkController : MonoBehaviour // Defining a class that controls the beer drinking simulation
{
    public Image beerLiquidImage; // A reference to the UI Image that represents the beer liquid
    public Sprite[] beerLevelSprites; // An array of 6 sprites representing the beer levels (from full to empty)
    public float delayBetweenLevels = 0.8f; // The time delay (in seconds) between each beer level change

    private int currentLevel = 0; // Tracks the current beer level (0 = full, 5 = empty)
    private bool[] levelTriggered; // An array to track whether each beer level has already been triggered
    private float lastLevelChangeTime = 0f; // Stores the time when the last beer level change occurred

    void Start() // Unity's built-in method that runs once when the script is first initialized
    {
        // Check if the beerLiquidImage is assigned in the Unity Inspector
        if (beerLiquidImage == null)
        {
            Debug.LogError("BeerLiquidImage is not assigned."); // Log an error if the image is missing
            return; // Exit the method to prevent further execution
        }

        // Check if the beerLevelSprites array is assigned and contains exactly 6 sprites
        if (beerLevelSprites == null || beerLevelSprites.Length != 6)
        {
            Debug.LogError("You must assign exactly 6 beer level sprites."); // Log an error if the sprites are missing or incorrect
            return; // Exit the method to prevent further execution
        }

        // Initialize the levelTriggered array to match the number of beer levels
        levelTriggered = new bool[beerLevelSprites.Length];

        // Set the initial beer level to full (level 0)
        SetBeerLevel(0);
    }

    void Update() // Unity's built-in method that runs every frame
    {
        // Get the phone's tilt using the accelerometer (Input.acceleration)
        Vector3 tilt = Input.acceleration;

        // Calculate the tilt angle on the X-axis (horizontal tilt) and scale it to degrees
        float zTilt = tilt.x * 90f;

        // Use the absolute value of the tilt angle to detect tilting in both directions
        float absoluteZTilt = Mathf.Abs(zTilt);

        // Check if enough time has passed since the last level change
        if (Time.time - lastLevelChangeTime < delayBetweenLevels)
            return; // If not enough time has passed, exit the method and do nothing

        // Check if the absolute tilt angle exceeds 15 degrees and the first level hasn't been triggered
        if (absoluteZTilt > 15f && !levelTriggered[1])
        {
            SetBeerLevel(1); // Change the beer level to 1
        }
        // Check if the absolute tilt angle exceeds 30 degrees and the second level hasn't been triggered
        else if (absoluteZTilt > 30f && !levelTriggered[2])
        {
            SetBeerLevel(2); // Change the beer level to 2
        }
        // Check if the absolute tilt angle exceeds 45 degrees and the third level hasn't been triggered
        else if (absoluteZTilt > 45f && !levelTriggered[3])
        {
            SetBeerLevel(3); // Change the beer level to 3
        }
        // Check if the absolute tilt angle exceeds 60 degrees and the fourth level hasn't been triggered
        else if (absoluteZTilt > 60f && !levelTriggered[4])
        {
            SetBeerLevel(4); // Change the beer level to 4
        }
        // Check if the absolute tilt angle exceeds 75 degrees and the fifth level hasn't been triggered
        else if (absoluteZTilt > 75f && !levelTriggered[5])
        {
            SetBeerLevel(5); // Change the beer level to 5 (empty)
            OnBeerFinished(); // Call the method to handle the beer being finished
        }
    }

    void SetBeerLevel(int level) // A method to update the beer level and change the UI sprite
    {
        // Check if the level is within the valid range (0 to 5)
        if (level >= 0 && level < beerLevelSprites.Length)
        {
            beerLiquidImage.sprite = beerLevelSprites[level]; // Update the UI image to the corresponding sprite
            currentLevel = level; // Update the current level to the new level
            levelTriggered[level] = true; // Mark this level as triggered
            lastLevelChangeTime = Time.time; // Record the time of this level change
        }
    }

    void OnBeerFinished() // A method that gets called when the beer is empty
    {
        Debug.Log("Beer is empty!"); // Log a message to the console
        QuoteManager.Instance.ShowQuote(false); // Show a random quote using the QuoteManager
    }
}
