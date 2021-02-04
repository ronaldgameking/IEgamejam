using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock Instance = null;
    
    [SerializeField] private Transform handTransform;
    
    private float timer;
    private float quarterTimer = 0;
    [SerializeField] private float speed = 4;

    [SerializeField] private ClockState currentClockState;
    public ClockState CurrentClockState
    {
        get => currentClockState;
        set => currentClockState = value;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        currentClockState = ClockState.Church;
    }

    private void Update()
    {
        timer = (timer + Time.deltaTime * speed) % 60;
        quarterTimer += Time.deltaTime * speed;

        if (quarterTimer >= 15)
            ChangeState();

        handTransform.eulerAngles = new Vector3(0, 0, -timer * 6);
    }

    private void ChangeState()
    {
        if (timer >= 45)
            currentClockState = ClockState.Home;
        else if (timer >= 30)
            currentClockState = ClockState.Fabric;
        else if (timer >= 15)
            currentClockState = ClockState.Cafe;
        else
            currentClockState = ClockState.Church;

        AudioManager.Instance.Play("Bell");
        quarterTimer -= 15;

        foreach (Character character in GameManager.Instance.Characters)
        {
            if (character.CompareTag("Human"))
                ((Human)character).SetNewTarget();
        }
    }
}