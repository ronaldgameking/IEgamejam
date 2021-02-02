using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Human : Character
{
    [SerializeField] [Range(0.1f, 3f)] private float minRandomTime = 1f;
    [SerializeField] [Range(1f, 10f)] private float maxRandomTime = 3f;
    
    private float randomDirectionTime;
    private float randomDirectionTimer;

    public GameManager Settings;
    public Zombie p_Zombie;
    private Vector3 Location;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        Settings = GameManager.GetComponent<GameManager>();

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
        if (Settings.InfectionPoints > 0)
        {
            Location = transform.position;
            Instantiate(p_Zombie, Location, Quaternion.identity);
            Settings.RemovePoints();
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("You don't have spare points!");
        }
    }
}
