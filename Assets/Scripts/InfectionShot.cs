using UnityEngine;
using UnityEngine.UI;

public class InfectionShot : MonoBehaviour
{
    public static InfectionShot Instance = null;
    
    [SerializeField] private Image fillImage;
    [SerializeField] private float rechargeTime = 8;
    private float timer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        timer = 0;
        fillImage.fillAmount = timer;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        fillImage.fillAmount = Mathf.Clamp01(timer / rechargeTime);
    }

    public void Reset()
    {
        timer = 0;
    }

    public bool CanShoot()
    {
        if (timer >= rechargeTime)
            return true;
        
        return false;
    }
}
