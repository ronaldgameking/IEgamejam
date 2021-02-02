using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D body;
    protected CircleCollider2D cirCollider;
    protected Vector2 direction;

    [SerializeField] protected float moveSpeed;

    protected virtual void Awake()
    {
        GetAllComponents();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void GetAllComponents()
    {
        body = GetComponent<Rigidbody2D>();
        cirCollider = GetComponent<CircleCollider2D>();
    }

    protected virtual void Move()
    {
        body.velocity = direction * moveSpeed;
    }

    private void RestrictMovement()
    {
        float minX = 0;
        float minY = 0;
        float maxX = 1;
        float maxY = 1;

        float x = Mathf.Clamp(transform.position.x + direction.x * moveSpeed, minX, maxX);
        float y = Mathf.Clamp(transform.position.y + direction.y * moveSpeed, minY, maxY);

        if (x <= minX && direction.x < 0)
            direction.x = 1;
        else if (x >= maxX && direction.x > 0)
            direction.x = -1f;
        
        if (y <= minY && direction.y < 0)
            direction.y = 1;
        else if (y >= maxY && direction.y > 0)
            direction.y = -1f;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{name} collided with {other.name}");
    }
}
