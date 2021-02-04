using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D body;
    protected CircleCollider2D cirCollider;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Vector2 direction = Vector2.right;
    [SerializeField] protected LayerMask objectLayerMask;
    [SerializeField] protected float searchRadius;
    protected float moveSpeed;
    
    [SerializeField] [Range(0.1f, 3f)] protected float minRandomTime = 0.3f;
    [SerializeField] [Range(1f, 10f)] protected float maxRandomTime = 1.5f;

    [SerializeField] [Range(30f, 90f)] protected float minSpeed = 70f;
    [SerializeField] [Range(60f, 150f)] protected float maxSpeed = 120f;
    
    private float randomDirectionTime;
    private float randomDirectionTimer;
    
    protected Transform target;
    protected bool isDead;
    protected bool canMove = true;
    public bool IsDead
    {
        get => isDead;
    }

    protected virtual void Awake()
    {
        GetAllComponents();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    protected virtual void Update()
    {
        Move(0);
    }

    protected virtual void GetAllComponents()
    {
        body = GetComponent<Rigidbody2D>();
        cirCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Move(int bounce)
    {
        if (!canMove)
        {
            body.velocity = Vector2.zero;
            return;
        }

        UpdateDirection();
        RestrictMovement(bounce);
        body.velocity = direction * moveSpeed;
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y);

        spriteRenderer.flipX = Mathf.Sign(direction.x) == 1 ? false : true;
    }

    private void UpdateDirection()
    {
        if (target == null)
            return;
        
        direction = (target.position - transform.position).normalized;
    }

    private void RestrictMovement(int bounce)
    {
        float radius = cirCollider.radius;
        float widthHalf = 1920 * 0.5f;
        float heightHalf = 1080 * 0.5f;
        float minX = -(widthHalf - radius);
        float minY = -(heightHalf - radius);
        float maxX = widthHalf - radius;
        float maxY = heightHalf - radius;

        Vector2 currentPosition = transform.position;

        float x = Mathf.Clamp(currentPosition.x + direction.x * (moveSpeed * Time.deltaTime), minX, maxX);
        float y = Mathf.Clamp(currentPosition.y + direction.y * (moveSpeed * Time.deltaTime), minY, maxY);

        if (x <= minX && direction.x < 0)
            direction.x = 1 * bounce;
        else if (x >= maxX && direction.x > 0)
            direction.x = -1f * bounce;
        
        if (y <= minY && direction.y < 0)
            direction.y = 1 * bounce;
        else if (y >= maxY && direction.y > 0)
            direction.y = -1f * bounce;
    }

    protected virtual void LookForNearbyCharacters()
    {
        Collider2D[] others = Physics2D.OverlapCircleAll(transform.position, searchRadius, objectLayerMask);

        target = GetClosestTarget(others);
    }

    private Transform GetClosestTarget(Collider2D[] colliders)
    {
        Transform newTarget = null;
        float closestDistance = float.MaxValue;
        
        foreach (Collider2D other in colliders)
        {
            float distance = Vector2.Distance(transform.position, (Vector2) other.transform.position + other.offset);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                newTarget = other.transform;
            }
        }

        return newTarget;
    }
    
    protected void UpdateTimers()
    {
        randomDirectionTimer -= Time.deltaTime;
        if (randomDirectionTimer <= 0f)
            GetRandomDirection();
    }
    
    protected void GetRandomDirection()
    {
        direction.x = Random.Range(0, 2) * 2 - 1;
        direction.y = Random.Range(0, 2) * 2 - 1;
        
        randomDirectionTime = Random.Range(minRandomTime, maxRandomTime);
        randomDirectionTimer = randomDirectionTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"{name} collided with {other.name}");
    }
    
    private void OnDrawGizmos()
    {
        if (cirCollider == null)
            cirCollider = GetComponent<CircleCollider2D>();
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + (Vector3)cirCollider.offset, searchRadius);
    }
}
