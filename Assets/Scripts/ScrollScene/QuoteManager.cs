using UnityEngine;                     // Provides access to Unity's core engine features like MonoBehaviour, GameObject, etc.
using UnityEngine.UI;                 // Allows use of Unity's UI components such as panels, buttons, and text elements.
using TMPro;                          // Gives access to the TextMeshPro system, which is used for rendering high-quality UI text.

public class QuoteManager : MonoBehaviour // Defines a class called QuoteManager that inherits from MonoBehaviour, allowing it to be attached to GameObjects in the Unity scene.
{
    public static QuoteManager Instance;       // A static instance of this class to implement the Singleton pattern. This makes it easy to access this class from other scripts globally.

    public TextMeshProUGUI quoteText;          // A reference to the TextMeshProUGUI component that will display the quote on the screen.
    public GameObject quotePanel;              // A reference to the panel GameObject that will be shown or hidden when displaying or hiding a quote.

    public string[] normalQuotes;              // An array of normal quote strings. A random one will be shown unless it's the final quote.
    public string finalQuote;                  // A single special quote that is shown when the game reaches a final point.

    private void Awake()                       // Unity's built-in method that is called when the object is initialized, before Start(). Often used to set up references or initial settings.
    {
        if (Instance == null) Instance = this; // Checks if the static Instance variable is null. If it is, assigns this object as the instance. Ensures only one instance exists (Singleton).
    }

    public void ShowQuote(bool isFinal)        // A method that shows the quote panel and sets the text to either a normal or final quote based on the 'isFinal' flag.
    {
        quotePanel.SetActive(true);            // Makes the quote panel visible in the UI so the user can see the quote.

        Debug.Log("QuotePanel Active: " + quotePanel.activeSelf); // Prints to the console whether the quote panel is active, useful for debugging.

        // If 'isFinal' is true, the final quote is displayed. If not, a random quote is selected from the normalQuotes array.
        quoteText.text = isFinal ? finalQuote : normalQuotes[Random.Range(0, normalQuotes.Length)];

        Debug.Log("Quote Text: " + quoteText.text); // Logs the exact quote text that is being shown, useful for testing and verifying correct behavior.
    }

    public void HideQuoteAndContinue()         // A method to hide the quote panel and perform the next logical action in the game (either end or continue).
    {
        quotePanel.SetActive(false);           // Hides the quote panel so it's no longer visible to the player.

        // Checks if the quote displayed is the final quote and it's not an empty string.
        if (!string.IsNullOrEmpty(finalQuote) && quoteText.text == finalQuote)
        {
            // This is where you could put code to end the game or return to the main menu,
            // since the final quote usually signifies the game is over.
        }
        
        
    }
}

