using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    public float Timer;
    public float lifetime = 30;

    protected override void Update()
    {
        GetInput();
        Move(0);

        Timer += Time.deltaTime;

        if (Timer > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void GetInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
