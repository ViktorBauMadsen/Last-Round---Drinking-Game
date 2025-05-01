using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    // Stores names of beers the player has already selected
    public List<string> selectedBeerNames = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectBeer(string beerName)
    {
        if (!selectedBeerNames.Contains(beerName))
        {
            selectedBeerNames.Add(beerName);
        }
    }

    public bool IsBeerSelected(string beerName)
    {
        return selectedBeerNames.Contains(beerName);
    }

    public bool AllBeersSelected(int totalBeers)
    {
        return selectedBeerNames.Count >= totalBeers;
    }

    public void ResetGame()
    {
        selectedBeerNames.Clear();
    }
}
