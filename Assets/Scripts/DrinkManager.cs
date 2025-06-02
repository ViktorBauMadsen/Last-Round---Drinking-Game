using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrinkManager : MonoBehaviour
{
    public GameObject beerPrefab;
    public Transform spawnPoint;

    public Drink Drink
    {
        get => default;
        set
        {
        }
    }

    public void SpawnBeer()
    {
        Instantiate(beerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
