using System.IO;
using TMPro;
using UnityEngine;


public class Dialogue_Assistant2 : MonoBehaviour
{
    // A serialized field to reference the TextWriter2 script, allowing customization in the Unity Editor.
    [SerializeField] private TextWriter2 TextWriter; // Use TextWriter2 instead of TextWriter

    // A private variable to hold a reference to the TextMeshProUGUI component for displaying text.
    private TextMeshProUGUI messageText;

    // A private variable to hold a reference to the AudioSource component for playing audio.
    private AudioSource TalkingAudioSource;

    // Unity's Awake method is called when the script instance is being loaded.
    private void Awake()
    {
        // If messageText is not already assigned, find the "messageText" child object and get its TextMeshProUGUI component.
        if (messageText == null)
        {
            messageText = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>();
        }
    }

    // Unity's Start method is called before the first frame update.
    private void Start()
    {
        // Store the original text from the messageText component.
        string originalText = messageText.text;

        // If messageText is not null, clear its text content.
        if (messageText != null)
        {
            originalText = messageText.text; // Retrieve the original text.
            messageText.text = string.Empty; // Clear the text.
        }

        // If both TextWriter and messageText are assigned, use TextWriter2 to animate the text display.
        if (TextWriter != null && messageText != null)
        {
            TextWriter.AddWriter(messageText, originalText, 0.08f); // Call AddWriter from TextWriter2 with a typing speed of 0.08 seconds per character.
        }
    }
}
