using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Static instance of GameData to implement the Singleton pattern
    public static GameData Instance;

    // List to store the names of selected beers
    public List<string> selectedBeerNames = new List<string>();

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if an instance of GameData already exists
        if (Instance == null)
        {
            // If no instance exists, assign this instance to the static Instance variable
            Instance = this;

            // Ensure this GameObject persists across scene loads
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate GameObject
            Destroy(gameObject);
        }
    }

    // Method to add a beer to the list of selected beers
    public void SelectBeer(string beerName)
    {
        // Add the beer name to the list
        selectedBeerNames.Add(beerName);
    }

    // Method to check if a specific beer has already been selected
    public bool IsBeerSelected(string beerName)
    {
        // Return true if the beer name exists in the list, otherwise false
        return selectedBeerNames.Contains(beerName);
    }

    // Method to check if all beers have been selected
    public bool AllBeersSelected(int totalBeers)
    {
        // Compare the number of selected beers with the total number of beers
        return selectedBeerNames.Count == totalBeers;
    }

    // Method to reset the game data
    public void ResetGame()
    {
        // Clear the list of selected beers
        selectedBeerNames.Clear();
    }
}
