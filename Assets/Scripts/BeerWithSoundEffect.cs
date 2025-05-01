using UnityEngine;

public class BeerWithSoundEffect : Beer
{
    private Beer _beer;
    private AudioSource _audioSource;  // Reference to the AudioSource component

    // Constructor takes the beer to decorate
    public BeerWithSoundEffect(Beer beer, AudioSource audioSource)
    {
        _beer = beer;
        _audioSource = audioSource;
    }

    // Override the Drink method to add sound effect before the original behavior
    public override void Drink()
    {
        PlaySoundEffect();  // Play the pouring sound
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
            _audioSource.Play();  // Play the audio clip
            Debug.Log("Playing pouring sound effect for " + _beer.beerName);
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned!");
        }
    }
}

