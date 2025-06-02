using UnityEngine;

public class GameManager : MonoBehaviour // GameManager inherits from MonoBehaviour for Unity lifecycle methods
{
    public static GameManager Instance; // Static instance for Singleton pattern

    public int totalBeers = 3; // Total number of beers to be drunk, set in Inspector
    private int beersDrunk = 0; // Counter for how many beers have been drunk

    public QuoteManager QuoteManager
    {
        get => default;
        set
        {
        }
    }

    private void Awake() // Unity method called when the script instance is loaded
    {
        if (Instance == null) Instance = this; // Assign this as the Singleton instance if not already set
        Input.gyro.enabled = true; // Enable the device gyroscope for input
    }

    public void OnBeerFinished() // Method to call when a beer is finished
    {
        beersDrunk++; // Increment the number of beers drunk

        if (beersDrunk < totalBeers) // If not all beers are finished
        {
            QuoteManager.Instance.ShowQuote(false); // Show a regular quote
        }
        else
        {
            QuoteManager.Instance.ShowQuote(true); // Show the final quote when all beers are finished
        }
    }
}
