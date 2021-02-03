using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Transform[] locations;

    private void Awake()
    {
        GetAllComponents();
    }

    private void GetAllComponents()
    {
        locations = new Transform[transform.childCount];

        for (int i = 0; i < locations.Length; i++)
        {
            locations[i] = transform.GetChild(i);
        }
    }

    public Transform GetLocation(ClockState clockState)
    {
        return locations[(int)clockState];
    }
}
