using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float Timer;

    public GameObject p_Clock;
    public GameObject p_Clock15;
    public GameObject p_Clock30;
    public GameObject p_Clock45;
    private Vector3 Location;

    private GameObject clockInstance;

    void Start()
    {
        Location = new Vector3(0, 0, -1);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 0 && Timer <= 15)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock, Location, p_Clock.transform.rotation);
        }
        if (Timer >= 15 && Timer <= 30)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock15, Location, p_Clock15.transform.rotation);
        }
        if (Timer >= 30 && Timer <= 45)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock30, Location, p_Clock30.transform.rotation);
        }
        if (Timer >= 45 && Timer <= 60)
        {
            if (clockInstance != null) Destroy(clockInstance);
            clockInstance = Instantiate(p_Clock45, Location, p_Clock45.transform.rotation);
        }

        if (Timer > 60)
        {
            Timer = 0;
        }
    }

}
