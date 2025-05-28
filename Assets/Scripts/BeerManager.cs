using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerManager : MonoBehaviour // BeerManager inherits from MonoBehaviour for Unity lifecycle methods
{
    public GameObject[] beers;       // Array to hold references to beer GameObjects, set in the Inspector
    public int totalBeers = 5;       // Total number of beers in the scene, can be set in the Inspector

    void Start() // Unity method called on the frame when a script is enabled
    {
        foreach (GameObject beer in beers) // Loop through each beer GameObject in the array
        {
            if (GameData.Instance.IsBeerSelected(beer.name)) // Check if this beer has already been selected using GameData singleton
            {
                beer.SetActive(false); // If selected, deactivate this beer GameObject so it doesn't appear
            }
        }

        if (GameData.Instance.AllBeersSelected(totalBeers)) // Check if all beers have been selected
        {
            SceneManager.LoadScene("QuoteScene"); // If so, load the "QuoteScene" (could show a final message instead)
        }
    }
}
