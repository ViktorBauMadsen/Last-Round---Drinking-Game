using UnityEngine;
using UnityEngine.UI;

public class GyroDrinkController : MonoBehaviour
{
    public Image beerLiquidImage;              // Assign your UI Image here
    public Sprite[] beerLevelSprites;          // 6 Sprites: Full to Empty

    private int currentLevel = 0;
    private bool[] levelTriggered;

    void Start()
    {
        Input.gyro.enabled = true;

        if (beerLevelSprites.Length != 6)
        {
            Debug.LogError("You must assign exactly 6 beer level sprites.");
            return;
        }

        levelTriggered = new bool[beerLevelSprites.Length];
        SetBeerLevel(0); // Start at full
    }

    void Update()
    {
        float tilt = Input.gyro.gravity.y;

        // Check thresholds and update level
        if (tilt < -0.15f && !levelTriggered[1])
        {
            SetBeerLevel(1);
        }
        else if (tilt < -0.35f && !levelTriggered[2])
        {
            SetBeerLevel(2);
        }
        else if (tilt < -0.55f && !levelTriggered[3])
        {
            SetBeerLevel(3);
        }
        else if (tilt < -0.75f && !levelTriggered[4])
        {
            SetBeerLevel(4);
        }
        else if (tilt < -0.95f && !levelTriggered[5])
        {
            SetBeerLevel(5);
            OnBeerFinished();
        }
    }

    // ? This is the missing method!
    void SetBeerLevel(int level)
    {
        if (level >= 0 && level < beerLevelSprites.Length)
        {
            beerLiquidImage.sprite = beerLevelSprites[level];
            currentLevel = level;
            levelTriggered[level] = true;
        }
    }

    void OnBeerFinished()
    {
        Debug.Log("Beer is empty!");
        // You can show your quote here
        // e.g. QuoteManager.Instance.ShowFinalQuote();
    }
}
