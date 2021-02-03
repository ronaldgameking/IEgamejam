using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timer;
    public float quarterTimer = 0;
    public float Speed = 4;
    public Transform handTransform;

    public AudioManager Bell;

    public ClockState currentclockstate;

    private void Start()
    {
        currentclockstate = ClockState.Church;
        GameObject audio = GameObject.Find("GameManager");
        Bell = audio.GetComponent<AudioManager>();
    }
    void Update()
    {
        timer = (timer + Time.deltaTime * Speed) % 60;
        quarterTimer += Time.deltaTime * Speed;

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
            currentclockstate = ClockState.Home;
        }
        else if (timer >= 30)
        {
            currentclockstate = ClockState.Fabric;
        }
        else if (timer >= 15)
        {
            currentclockstate = ClockState.Cafe;
        }
        else if (timer >= 0)
        {
            currentclockstate = ClockState.Church;
        }
        PlayBell();
        quarterTimer -= 15;
    }

}
public enum ClockState { Church, Cafe, Fabric, Home }