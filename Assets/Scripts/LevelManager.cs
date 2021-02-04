using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    private Transform[] locations;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        GetAllComponents();
    }

    private void GetAllComponents()
    {
        locations = new Transform[transform.childCount];

        for (int i = 0; i < locations.Length; i++)
        {
            locations[i] = transform.GetChild(i);
        }
    }

    public Transform GetCurrentLocation()
    {
        return locations[(int)Clock.Instance.CurrentClockState];
    }
}
