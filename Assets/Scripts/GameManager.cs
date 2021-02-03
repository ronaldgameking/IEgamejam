using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
