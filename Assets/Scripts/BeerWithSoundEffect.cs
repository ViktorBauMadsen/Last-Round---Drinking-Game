using UnityEngine;

public class BeerWithSoundEffect : Beer // Inherit from Beer abstract class
{
    private Beer _beer; // Reference to the Beer object being decorated
    private AudioSource _audioSource;  // Reference to the AudioSource component for sound effects

    // Constructor takes the beer to decorate and the AudioSource for sound
    public BeerWithSoundEffect(Beer beer, AudioSource audioSource)
    {
        _beer = beer; // Store the Beer object to decorate
        _audioSource = audioSource; // Store the AudioSource for playing sounds
    }

    // Override the Drink method to add sound effect before the original behavior
    public override void Drink()
    {
        PlaySoundEffect();  // Play the pouring sound effect
        _beer.Drink();  // Call the original Drink method on the decorated beer
    }

    // Play sound effect (pouring sound)
    private void PlaySoundEffect()
    {
        // Check if the AudioSource and audio clip are assigned
        if (_audioSource != null)
        {
            // Optionally set the clip dynamically if you have multiple sound effects
            // _audioSource.clip = pouringSoundClip;

            Debug.Log("Playing pouring sound effect for " + _beer.beerName); // Log which beer's sound is playing
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned!"); // Warn if AudioSource is missing
        }
    }
}

