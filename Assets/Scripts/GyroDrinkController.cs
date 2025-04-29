using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GyroDrinkController : MonoBehaviour
{
    private Drink currentDrink;

    private void Start()
    {
        Input.gyro.enabled = true;
        currentDrink = FindObjectOfType<Beer>();
    }

    private void Update()
    {
        if (currentDrink != null)
        {
            float tilt = Input.gyro.gravity.x;
            currentDrink.DrinkAmount(Mathf.Abs(tilt));
        }
    }
}
