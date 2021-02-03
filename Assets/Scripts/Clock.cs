using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timer;

    // TODO: ????????????
    public GameObject p_Clock;
    //public GameObject p_Clock15;
    //public GameObject p_Clock30;
    //public GameObject p_Clock45;

    private Vector3 Location;

    [SerializeField] [ReadOnly] private GameObject clockInstance;

    void Start()
    {
        Location = new Vector3(0, 0, -1);
        clockInstance = Instantiate(p_Clock, Location, p_Clock.transform.rotation);
    }

    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= 0 && timer <= 15)
        {
            clockInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (timer > 15 && timer <= 30)
        {
            clockInstance.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (timer > 30 && timer <= 45)
        {
            clockInstance.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (timer > 45 && timer <= 60)
        {
            clockInstance.transform.rotation = Quaternion.Euler(0, 0, 90)  ;
        }

        if (timer > 60)
        {
            timer = 0;
        }
    }

}
