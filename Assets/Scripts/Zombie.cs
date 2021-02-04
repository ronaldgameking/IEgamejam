using System;
using UnityEngine;

public class Zombie : Character
{
    private float lifeTimer;
    [SerializeField] private float lifeTime = 30;

    protected override void Awake()
    {
        base.Awake();
        lifeTimer = lifeTime;
        isDead = true;
    }

    protected override void Update()
    {
        GetInput();
        Move(0);

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
            GameManager.Instance.RemoveCharacter(this, null);
    }

    private void GetInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Human"))
        {
            // ((Human)other).BecomeZombie();
            // Debug.Log($"{name} should eat and infect {other.name}");
        }
    }
}
