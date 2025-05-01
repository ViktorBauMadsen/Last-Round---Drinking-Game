using TMPro;
using UnityEngine;

public class TextWriter2 : MonoBehaviour
{
    private TextMeshProUGUI uiText; // Reference to the TextMeshProUGUI component
    private string textToWrite; // The text to display character by character
    private int characterIndex; // Tracks the current character being displayed
    private float timePerCharacter; // Time delay between displaying each character
    private float timer; // Timer to control the character display timing

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText; // Assign the UI text component
        this.textToWrite = textToWrite; // Assign the text to write
        this.timePerCharacter = timePerCharacter; // Assign the time delay per character
        characterIndex = 0; // Reset the character index
    }

    private void Update()
    {
        if (uiText != null) // Check if there is text to write
        {
            timer -= Time.deltaTime; // Decrease the timer by the time elapsed since the last frame
            while (timer <= 0f) // If the timer reaches or goes below zero
            {
                timer += timePerCharacter; // Reset the timer for the next character
                characterIndex++; // Move to the next character
                uiText.text = textToWrite.Substring(0, characterIndex); // Update the displayed text

                if (characterIndex >= textToWrite.Length) // If all characters have been displayed
                {
                    uiText = null; // Stop writing
                    return; // Exit the method
                }
            }
        }
    }
}