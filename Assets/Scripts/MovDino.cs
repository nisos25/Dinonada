using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovDino : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mov;

    [SerializeField]
    float movSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }


    void FixedUpdate()
    {
        mov = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rb.velocity = mov*movSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Puesto"))
        {
            ///entra el objeto a pantalla
            //collision.bounds.max.x;
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
