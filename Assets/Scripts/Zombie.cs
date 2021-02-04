using System;
using UnityEngine;

public class Zombie : Character
{
    private float lifeTimer;
    [SerializeField] private float lifeTime = 10;

    protected override void Awake()
    {
        base.Awake();
        lifeTimer = lifeTime;
        isDead = true;
    }

    protected override void Update()
    {
        Move(0);
        UpdateTimers();

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
            GameManager.Instance.RemoveCharacter(this, null);
    }

}
