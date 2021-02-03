using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Human : Character
{
    [SerializeField] [Range(0.1f, 3f)] private float minRandomTime = 0.3f;
    [SerializeField] [Range(1f, 10f)] private float maxRandomTime = 1.5f;

    [SerializeField] [Range(10f, 30f)] private float minSpeed = 15f;
    [SerializeField] [Range(30f, 60f)] private float maxSpeed = 45f;
    
    private float randomDirectionTime;
    private float randomDirectionTimer;

    public InfectionShot infectionShot;
    public GameManager Settings;
    public Zombie p_Zombie;
    private Vector3 Location;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        GameObject Infection = GameObject.Find("Canvas/ShotObject");
        infectionShot = Infection.GetComponent<InfectionShot>();
        GameObject gameManager = GameObject.Find("GameManager");
        Settings = gameManager.GetComponent<GameManager>();

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
        if (infectionShot.CanShoot())
        {
            //Settings.RemoveHuman();
            Location = transform.position;
            Instantiate(p_Zombie, Location, Quaternion.identity);
            infectionShot.Reset();
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("The Syringe is empty!");
        }
    }
}
