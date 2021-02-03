using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timer;
    public float Speed = 4;
    public Transform handTransform;

    void Update()
    {
        timer = (timer + Time.deltaTime * Speed) % 60;

        handTransform.rotation = Quaternion.Euler(0, 0, -timer * 6);
    }

}
