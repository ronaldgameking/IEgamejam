using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSpriteRenderOrder : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -Mathf.RoundToInt(transform.position.y - 32);
    }
}
