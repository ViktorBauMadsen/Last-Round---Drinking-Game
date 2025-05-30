using System.Collections;                      // Allows use of coroutines (IEnumerator functions)
using System.Collections.Generic;              // Enables use of generic collections like List<T>
using UnityEngine;                             // Access to Unity engine features
using UnityEngine.SceneManagement;             // Allows loading and switching between scenes

public class RandomScrollAnimator : MonoBehaviour // Defines a script that handles showing and animating scrolls
{
    public List<GameObject> scrolls;           // A list of scroll prefabs to be shown randomly (excluding the final scroll)
    public GameObject finalScroll;             // A specific scroll shown as the last one, signaling end of sequence
    public float scrollDuration = 5f;          // Duration of the scroll animation in seconds
    public float speed = 400f;                 // Not used in the animation here but could relate to speed of movement

    private static List<int> shownIndexes = new List<int>(); // Tracks which scrolls have already been shown to avoid repetition
    private static int totalScrollsShown = 0;                // Counts how many scrolls have been shown so far

    private void Start() // Unity method called when the GameObject is first activated in the scene
    {
        ShowScroll(); // Begins the scroll display process as soon as the scene starts
    }

    void ShowScroll()
    {
        totalScrollsShown++; // Increment the counter to track how many scrolls we've shown so far

        GameObject scrollToShow = null; // Placeholder for the scroll we're about to display

        if (totalScrollsShown < 5) // If we haven't shown 4 scrolls yet...
        {
            int index;
            // Choose a random scroll index that hasn't been used before
            do
            {
                index = Random.Range(0, scrolls.Count);
            } while (shownIndexes.Contains(index)); // Repeat until an unused scroll is found

            shownIndexes.Add(index); // Remember this scroll so it's not shown again
            scrollToShow = Instantiate(scrolls[index], transform); // Create the scroll in the scene under this object
        }
        else
        {
            // If we've already shown 4 scrolls, it's time to show the final one
            scrollToShow = Instantiate(finalScroll, transform);
        }

        // Animate the scroll sliding in from the left edge of the screen to the center
        RectTransform rt = scrollToShow.GetComponent<RectTransform>(); // Access the UI layout info of the scroll
        rt.anchoredPosition = new Vector2(-Screen.width, 0);           // Start the scroll just off-screen to the left

        StartCoroutine(AnimateScroll(rt, scrollDuration)); // Begin the animation using a coroutine
    }

    IEnumerator AnimateScroll(RectTransform rt, float duration)
    {
        Vector2 startPos = rt.anchoredPosition; // Start position (off-screen to the left)
        Vector2 endPos = Vector2.zero;          // End position (center of screen)
        float elapsed = 0f;                     // Track how long the animation has been running

        // Gradually move the scroll from left to center using linear interpolation
        while (elapsed < duration)
        {
            rt.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / duration); // Interpolates position smoothly
            elapsed += Time.deltaTime; // Advance the timer based on frame time
            yield return null;         // Wait until the next frame
        }

        rt.anchoredPosition = endPos; // Make sure it ends at the exact center position

        // After animation finishes, wait 2 seconds and then load a new scene
        yield return StartCoroutine(WaitAndSwitchScene());
    }

    IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(2f); // Pause for 2 seconds before moving on

        if (totalScrollsShown < 5) // If not all scrolls are shown yet
        {
            SceneManager.LoadScene("SelectBeerScene"); // Load the scene where the next beer or scroll is selected
        }
        else
        {
            SceneManager.LoadScene("EndScene"); // Final scene after all scrolls are shown

            // Reset static tracking variables so the scroll system starts fresh if restarted
            shownIndexes.Clear(); 
            totalScrollsShown = 0;
        }
    }
}
