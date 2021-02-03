using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timer;
    public float quarterTimer = 0;
    public float speed = 4;
    public Transform handTransform;

    public AudioManager Bell;
    public ClockState currentClockState;

    private void Start()
    {
        currentClockState = ClockState.Church;
        GameObject audio = GameObject.Find("GameManager");
        Bell = audio.GetComponent<AudioManager>();
    }
    void Update()
    {
        timer = (timer + Time.deltaTime * speed) % 60;
        quarterTimer += Time.deltaTime * speed;

        handTransform.rotation = Quaternion.Euler(0, 0, -timer * 6);

        if (quarterTimer >= 15)
        {
            ChangeState();
        }
    }

    public void PlayBell()
    {
        Bell.Play("Bell");
    }

    public void ChangeState()
    {
        if (timer >= 45)
        {
            currentClockState = ClockState.Home;
        }
        else if (timer >= 30)
        {
            currentClockState = ClockState.Fabric;
        }
        else if (timer >= 15)
        {
            currentClockState = ClockState.Cafe;
        }
        else if (timer >= 0)
        {
            currentClockState = ClockState.Church;
        }
        PlayBell();
        quarterTimer -= 15;
    }
}

public enum ClockState : int
{
    Church = 0,
    Cafe,
    Fabric,
    Home
}