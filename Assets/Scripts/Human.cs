﻿using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Human : Character
{
    [SerializeField] private Zombie zombiePrefab;
    private int Chance;

    protected override void Awake()
    {
        base.Awake();
        isDead = false;
    }

    protected void Start()
    {
        SetNewTarget();
    }

    protected virtual void Update()
    {
        Move(1);
        Chance = Random.Range(0, 3);
    }

    private void OnMouseDown()
    {
        if (InfectionShot.Instance.CanShoot())
            TurnToZombie();
    }

    public void SetNewTarget()
    {
        if (Chance == 0)
        {
            target = LevelManager.Instance.GetCurrentLocation();
        }
    }

    public void TurnToZombie()
    {
        isDead = true;
        canMove = false;
        animator.SetTrigger("Turn");
    }

    public void BecomeZombie()
    {
        Debug.Log($"{name} Made a zombie");
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
