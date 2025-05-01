using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep music playing between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
}
