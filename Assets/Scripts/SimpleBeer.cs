using UnityEngine;

public class SimpleBeer : Beer
{
    public SimpleBeer(string name)
    {
        beerName = name;  // Assign the name of the beer
    }

    public override void Drink()
    {
        Debug.Log($"Drinking {beerName}");
    }
}