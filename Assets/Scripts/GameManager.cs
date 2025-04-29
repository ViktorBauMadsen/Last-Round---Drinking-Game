using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalBeers = 3;
    private int beersDrunk = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        Input.gyro.enabled = true;
    }

    public void OnBeerFinished()
    {
        beersDrunk++;

        if (beersDrunk < totalBeers)
        {
            QuoteManager.Instance.ShowQuote(false);
        }
        else
        {
            QuoteManager.Instance.ShowQuote(true); // Final quote
        }
    }
}
