using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomScrollAnimator : MonoBehaviour
{
    public List<GameObject> scrolls; // Assign 4 scrolls here (not the final one)
    public GameObject finalScroll;   // Assign the last scroll here
    public float scrollDuration = 5f;
    public float speed = 400f;

    private static List<int> shownIndexes = new List<int>();
    private static int totalScrollsShown = 0;

    private void Start()
    {
        ShowScroll();
    }

    void ShowScroll()
    {
        totalScrollsShown++;

        GameObject scrollToShow = null;

        if (totalScrollsShown < 5)
        {
            // Pick a random scroll that hasn't been shown yet
            int index;
            do
            {
                index = Random.Range(0, scrolls.Count);
            } while (shownIndexes.Contains(index));

            shownIndexes.Add(index);
            scrollToShow = Instantiate(scrolls[index], transform);
        }
        else
        {
            // Show the final scroll
            scrollToShow = Instantiate(finalScroll, transform);
        }

        // Animate scroll from left to center using coroutine
        RectTransform rt = scrollToShow.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(-Screen.width, 0); // Start off-screen

        StartCoroutine(AnimateScroll(rt, scrollDuration));
    }

    IEnumerator AnimateScroll(RectTransform rt, float duration)
    {
        Vector2 startPos = rt.anchoredPosition;
        Vector2 endPos = Vector2.zero;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            rt.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rt.anchoredPosition = endPos;

        // After animation completes, wait 2 seconds then switch scene
        yield return StartCoroutine(WaitAndSwitchScene());
    }

    IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        if (totalScrollsShown < 5)
        {
            SceneManager.LoadScene("SelectBeerScene");
        }
        else
        {
            SceneManager.LoadScene("HomeScreen");
            shownIndexes.Clear();
            totalScrollsShown = 0;
        }
    }
}