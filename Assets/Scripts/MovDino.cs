using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovDino : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    AudioSource audioSource;

    Vector2 mov=Vector2.zero;

    [SerializeField]
    float movSpeed=0;

    bool inverted=true;

    Vector2 pastPosition;

    bool isPlayingSound;

    public int Money { get; set; }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.gravityScale = 0;
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        #region RbMovimiento
        mov = new Vector2 (h,v);
        rb.velocity = mov*movSpeed;
        anim.SetFloat("vel",Mathf.Abs(rb.velocity.magnitude));
        #endregion
        #region AudioSteps
        if(!isPlayingSound && Mathf.Abs(rb.velocity.magnitude) > 0)
        {
            audioSource.Play();
            isPlayingSound = true;
        }
        else
        {
            if(Mathf.Abs(rb.velocity.magnitude) <= 0)
            {
                audioSource.Stop();
                isPlayingSound = false;
            }
            
        }
        #endregion
        #region Inverted
        if(rb.velocity.x > 0)
        {
            inverted = false;
        }else if(rb.velocity.x < 0)
        {
            inverted = true;
        }
        transform.localScale = inverted ? new Vector3(.46f, .46f, .46f): new Vector3(-.46f, .46f,.46f);
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Puesto"))
        {
            ///entra el objeto a pantalla
            //collision.bounds.max.x;
            pastPosition = transform.position;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Puesto"))
        {
            ///sale el objeto a pantalla
            //collision.bounds.max.x;
        }
    }
}
