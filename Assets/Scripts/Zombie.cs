using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    protected override void Update()
    {
        GetInput();
        Move(0);
    }

    private void GetInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        Debug.Log($"{name} should eat and infect {other.name}");
    }
}
