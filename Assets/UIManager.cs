using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    [SerializeField] private TMP_Text populationText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void UpdateUI()
    {
        populationText.text = $"{GameManager.Instance.zombieAmount}/100";
    }
}
