using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Clock clockInstance;
    [ReadOnly] public float timer;
    public float quarterTimer = 0;
    public float speed = 4;

    private void Update()
    {
        //timer += Time.deltaTime;
        timer = (timer + Time.deltaTime * speed) % 60;
        quarterTimer += Time.deltaTime * speed;

        if (quarterTimer >= 15)
        {
            clockInstance.ChangeState(timer);
        }
    }
}
