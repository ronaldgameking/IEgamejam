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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{name} collided with {other.name}");
    }
}
