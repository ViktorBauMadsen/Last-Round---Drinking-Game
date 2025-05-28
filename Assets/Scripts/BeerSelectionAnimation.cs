using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this to use IEnumerator

public class BeerSelectAnimation : MonoBehaviour // Inherit from MonoBehaviour for Unity lifecycle
{
    public string animationName = "Beer1_Select"; // Name of the animation to play, set in Inspector

    private Animator anim; // Reference to the Animator component
    private bool hasBeenSelected = false; // Flag to prevent multiple selections
    public string beerName;  // Name of the beer, set in Inspector or from a list
    private Beer _beer; // Reference to a Beer object

    // Add a reference to the AudioSource component
    private AudioSource _audioSource; // Reference to the AudioSource for sound effects

    void Awake() // Unity method called when the script instance is loaded
    {
        anim = GetComponent<Animator>(); // Get the Animator component attached to this GameObject
    }

    void Start() // Unity method called before the first frame update
    {
        _audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
        _beer = new SimpleBeer(beerName); // Create a basic Beer object (SimpleBeer class assumed to exist)
        _beer = new BeerWithSoundEffect(_beer, _audioSource); // Decorate the Beer with sound effect functionality
    }

    public void PlayAnimation() // Method to play the selection animation
    {
        if (hasBeenSelected) return; // Prevent multiple selections
        hasBeenSelected = true; // Mark as selected

        anim.Play(animationName); // Play the specified animation

        GameData.Instance.SelectBeer(gameObject.name); // Add this beer to the selected list in GameData

        StartCoroutine(PlaySoundEffectWithDelay()); // Start coroutine to play sound after a delay

        _beer.Drink(); // Call the Drink method (with sound effect)

        Invoke("DisableSelf", 3.0f); // Disable this GameObject after 3 seconds (animation duration)
    }

    private IEnumerator PlaySoundEffectWithDelay() // Coroutine to delay sound effect
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        if (_audioSource != null) // If AudioSource is assigned
        {
            _audioSource.Play(); // Play the sound effect
            Debug.Log("Playing pouring sound effect for " + beerName); // Log the action
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned!"); // Warn if AudioSource is missing
        }
    }

    void DisableSelf() // Method to disable this GameObject and load next scene
    {
        gameObject.SetActive(false); // Deactivate this GameObject
        SceneManager.LoadScene("DrinkBeerScene"); // Load the "DrinkBeerScene"
    }
}
