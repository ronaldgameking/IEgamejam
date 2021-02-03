using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Clock clockInstance;
    public float timer;
    public float quarterTimer = 0;
    public float speed = 4;

    public float zombieAmount = 99;
    public TMP_Text indicator;

    private void Update()
    {
        timer = (timer + Time.deltaTime * speed) % 60;
        quarterTimer += Time.deltaTime * speed;

        if (quarterTimer >= 15)
        {
            clockInstance.ChangeState(timer);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        indicator.text = (zombieAmount + "/100");
    }

    public void RemoveHuman()
    {
        zombieAmount--;
    }

}