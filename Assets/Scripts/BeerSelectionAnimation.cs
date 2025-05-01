using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerSelectAnimation : MonoBehaviour
{
    public string quote;
    public string animationName = "Beer1_Select"; // Set in Inspector for each beer

    private Animator anim;
    private bool hasBeenSelected = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (hasBeenSelected) return;
        hasBeenSelected = true;

        anim.Play(animationName);

        // Add this beer to GameData
      

        // Optional: hide or disable beer after animation
        Invoke("DisableSelf", 3.0f); // wait for animation to finish
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("DrinkBeerScene");
    }
}
