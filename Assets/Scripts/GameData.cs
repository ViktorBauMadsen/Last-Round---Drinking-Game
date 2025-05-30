using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour // Inherit from MonoBehaviour for Unity lifecycle
{
    public static GameData Instance; // Static instance for Singleton pattern

    public List<string> selectedBeerNames = new List<string>(); // List to store names of selected beers

    private void Awake() // Unity method called when the script instance is loaded
    {
        if (Instance == null) // If no instance exists yet
        {
            Instance = this; // Set this as the Singleton instance
            DontDestroyOnLoad(gameObject); // Make this GameObject persist across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameObject if instance already exists
        }
    }

    public void SelectBeer(string beerName) // Add a beer to the list of selected beers
    {
        selectedBeerNames.Add(beerName); // Add the beer name to the list
    }

    public bool IsBeerSelected(string beerName) // Check if a beer has already been selected
    {
        return selectedBeerNames.Contains(beerName); // Return true if beer is in the list
    }

    public bool AllBeersSelected(int totalBeers) // Check if all beers have been selected
    {
        return selectedBeerNames.Count == totalBeers; // Return true if selected count matches total
    }

    public void ResetGame() // Reset the game data
    {
        selectedBeerNames.Clear(); // Clear the list of selected beers
    }
}
