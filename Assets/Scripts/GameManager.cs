using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    public float zombieAmount = 99;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void RemoveCharacter(bool isZombie)
    {
        zombieAmount--;
        UIManager.Instance.UpdateUI();
    }
}