using UnityEngine;

public abstract class Beer : MonoBehaviour // Abstract class for Beer, inherits from MonoBehaviour
{
    public string beerName; // Name of the beer

    public abstract void Drink(); // Abstract method to be implemented by subclasses for drinking behavior
}

