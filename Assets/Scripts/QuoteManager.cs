using UnityEngine;
using UnityEngine.UI;

public class QuoteManager : MonoBehaviour
{
    public static QuoteManager Instance;
    public Text quoteText;
    public GameObject quotePanel;

    public string[] normalQuotes;
    public string finalQuote;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowQuote(bool isFinal)
    {
        quotePanel.SetActive(true);
        quoteText.text = isFinal ? finalQuote : normalQuotes[Random.Range(0, normalQuotes.Length)];
    }

    public void HideQuoteAndContinue()
    {
        quotePanel.SetActive(false);
        if (!string.IsNullOrEmpty(finalQuote) && quoteText.text == finalQuote)
        {
            // End game or go to menu
        }
        else
        {
            FindObjectOfType<DrinkManager>().SpawnBeer();
        }
    }
}
