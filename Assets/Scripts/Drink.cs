using UnityEngine;

public abstract class Drink : MonoBehaviour
{
    public float currentFill = 1f;
    public abstract void DrinkAmount(float tilt);
}
