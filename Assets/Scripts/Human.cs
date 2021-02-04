using System.Collections;
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
    
    [SerializeField] private Zombie zombiePrefab;

    protected override void Awake()
    {
        base.Awake();
        isDead = false;
    }

    protected void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // GetRandomDirection();
        SetNewTarget();
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
        if (InfectionShot.Instance.CanShoot())
            TurnToZombie();
    }

    public void SetNewTarget()
    {
        target = LevelManager.Instance.GetCurrentLocation();
    }

    public void TurnToZombie()
    {
        isDead = true;
        canMove = false;
        animator.SetTrigger("Turn");
    }
    
    public void BecomeZombie()
    {
        Character zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity).GetComponent<Character>();
        GameManager.Instance.RemoveCharacter(this, zombie);
        InfectionShot.Instance.Reset();
        Destroy(gameObject);
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead)
            return;
        
        if (other.CompareTag("Zombie"))
            BecomeZombie();
    }
}
