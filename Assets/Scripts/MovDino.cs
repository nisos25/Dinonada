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

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.gravityScale = 0;
    }


    void FixedUpdate()
    {
        mov = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rb.velocity = mov*movSpeed;
        anim.SetFloat("vel",Mathf.Abs(rb.velocity.x));

        if(!isPlayingSound && Mathf.Abs(rb.velocity.magnitude) > 0)
        {
            audioSource.Play();
            isPlayingSound = true;
        }
        else
        {
            if(Mathf.Abs(rb.velocity.x) <= 0)
            {
                audioSource.Stop();
                isPlayingSound = false;
            }
            
        }

        if(rb.velocity.x > 0)
        {
            inverted = false;
        }else if(rb.velocity.x < 0)
        {
            inverted = true;
        }
        transform.localScale = inverted ? new Vector3(1, 1, 1): new Vector3(-1, 1, 1);
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
