using UnityEngine;
using Random = UnityEngine.Random;

public class Human : Character
{
    [SerializeField] [Range(0.1f, 3f)] private float minRandomTime = 0.3f;
    [SerializeField] [Range(1f, 10f)] private float maxRandomTime = 1.5f;

    [SerializeField] [Range(30f, 90f)] private float minSpeed = 70f;
    [SerializeField] [Range(60f, 150f)] private float maxSpeed = 120f;
    
    private float randomDirectionTime;
    private float randomDirectionTimer;
    
    public Zombie zombiePrefab;
    private Vector2 targetLocation;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        GetRandomDirection();

    }

    protected virtual void Update()
    {
        Move(1);
        UpdateTimers();
    }
    
    private void UpdateTimers()
    {
        randomDirectionTimer -= Time.deltaTime;
        if (randomDirectionTimer <= 0f)
            GetRandomDirection();
    }

    private void GetRandomDirection()
    {
        direction.x = Random.Range(0, 2) * 2 - 1;
        direction.y = Random.Range(0, 2) * 2 - 1;
        
        randomDirectionTime = Random.Range(minRandomTime, maxRandomTime);
        randomDirectionTimer = randomDirectionTime;
    }

    private void OnMouseDown()
    {
        if (InfectionShot.Instance.CanShoot() && GameManager.Instance.zombieAmount > 1)
            TurnToZombie();
    }

    public void TurnToZombie()
    {
        GameManager.Instance.RemoveCharacter(false);
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        InfectionShot.Instance.Reset();
        Destroy(gameObject);
    }
}
