using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerManager : MonoBehaviour
{
    public GameObject[] beers;       // Drag & drop your 5 beer GameObjects in the Inspector
    public int totalBeers = 5;

    void Start()
    {
        foreach (GameObject beer in beers)
        {
            if (GameData.Instance.IsBeerSelected(beer.name))
            {
                beer.SetActive(false);
            }
        }

        if (GameData.Instance.AllBeersSelected(totalBeers))
        {
            SceneManager.LoadScene("QuoteScene"); // Or show a final message instead
        }
    }
}
