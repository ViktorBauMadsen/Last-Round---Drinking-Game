using UnityEngine;

public class Beer : Drink
{
    public SpriteRenderer beerFillSprite;

    public override void DrinkAmount(float tilt)
    {
        if (tilt > 0.5f)
        {
            currentFill -= Time.deltaTime * tilt * 0.1f;
            currentFill = Mathf.Clamp01(currentFill);
            beerFillSprite.transform.localScale = new Vector3(1, currentFill, 1);

            if (currentFill <= 0)
            {
                GameManager.Instance.OnBeerFinished();
                Destroy(gameObject); // or hide
            }
        }
    }
}
