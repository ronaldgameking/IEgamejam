using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timer;

    // TODO: ????????????
    public GameObject p_Clock;
    public GameObject p_Clock15;
    public GameObject p_Clock30;
    public GameObject p_Clock45;
    
    private Vector3 Location;

    [SerializeField] private GameObject clockInstance;

    void Start()
    {
        Location = new Vector3(0, 0, -1);
    }

    void Update()
    {
        timer += Time.deltaTime;

        return;


        // TODO: RE-WRITE THIS SCRIPT!!! (Please...)
        // Note: Never Instatiate or Destroy in runtime. Very in efficient and expensive for the computer.

        if (timer >= 0 && timer <= 15)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock, Location, p_Clock.transform.rotation);
        }
        if (timer > 15 && timer <= 30)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock15, Location, p_Clock15.transform.rotation);
        }
        if (timer > 30 && timer <= 45)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock30, Location, p_Clock30.transform.rotation);
        }
        if (timer > 45 && timer <= 60)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock45, Location, p_Clock45.transform.rotation);
        }

        if (timer > 60)
        {
            timer = 0;
        }
    }

}
