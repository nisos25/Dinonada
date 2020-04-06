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
    
    [SerializeField]private Sprite raw;
    [SerializeField]private Sprite cooked;
    [SerializeField]private Sprite burnt;

    private SpriteRenderer renderer;
    
    private void Awake()
    {
        State = EmpanadaState.Raw;
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.Find("Bottom").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("Top").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        if (State == EmpanadaState.Raw)
        {
            renderer.sprite = raw;
        }

        if (State == EmpanadaState.Cooked)
        {
            renderer.sprite = cooked;
        }
        
        if (State == EmpanadaState.Burnt)
        {
            renderer.sprite = burnt;
        }
    }
}
