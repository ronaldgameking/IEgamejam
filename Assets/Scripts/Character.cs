using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D body;
    protected CircleCollider2D cirCollider;
    protected SpriteRenderer spriteRenderer;
    protected Vector2 direction;

    [SerializeField] protected float moveSpeed;

    protected virtual void Awake()
    {
        GetAllComponents();
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
    }

    protected virtual void Move(int bounce)
    {
        RestrictMovement(bounce);
        body.velocity = direction * moveSpeed;
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y);
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"{name} collided with {other.name}");
    }
}
