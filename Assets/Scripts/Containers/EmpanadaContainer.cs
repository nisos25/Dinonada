using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmpanadaState
{
    Raw,
    Cooked,
    Burnt
}

public class EmpanadaContainer : MonoBehaviour
{
    public EmpanadaState State { get; set; }

    private void Awake()
    {
        State = EmpanadaState.Raw;
    }

    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.Find("Bottom").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
