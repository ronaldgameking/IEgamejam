using UnityEngine;

public class GameManager : MonoBehaviour
{
    [ReadOnly] public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
