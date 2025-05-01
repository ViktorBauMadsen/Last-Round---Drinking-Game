using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this to use IEnumerator

public class BeerSelectAnimation : MonoBehaviour
{
    public string animationName = "Beer1_Select"; // Set in Inspector for each beer

    private Animator anim;
    private bool hasBeenSelected = false;
    public string beerName;  // Beer name (you can assign it in the Inspector or from a list)
    private Beer _beer;

    // Add a reference to the AudioSource component
    private AudioSource _audioSource;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        // Get the AudioSource component on the same GameObject
        _audioSource = GetComponent<AudioSource>();
        // Initialize the Beer class for any beer selected
        _beer = new SimpleBeer(beerName); // SimpleBeer is just a basic class, see below
        // Decorate the beer with sound effect
        _beer = new BeerWithSoundEffect(_beer, _audioSource);
    }

    public void PlayAnimation()
    {
        if (hasBeenSelected) return;
        hasBeenSelected = true;

        anim.Play(animationName);

        // Add this beer to GameData
        GameData.Instance.SelectBeer(gameObject.name);

        // Delay the sound effect to sync with the animation
        StartCoroutine(PlaySoundEffectWithDelay());

        _beer.Drink();


        // Optional: hide or disable beer after animation
        Invoke("DisableSelf", 3.0f); // wait for animation to finish
    }

    private IEnumerator PlaySoundEffectWithDelay()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        // Play the sound effect
        if (_audioSource != null)
        {
            _audioSource.Play();
            Debug.Log("Playing pouring sound effect for " + beerName);
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned!");
        }
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("DrinkBeerScene");
    }
}
