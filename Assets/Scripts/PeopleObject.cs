using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PeopleObject : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool facingRight;
    [SerializeField]
    private int timepoInteresado;
    [SerializeField]
    private int cantidadEmpanadas;

    private Rigidbody2D rb;

    void Start()
    {
        facingRight = transform.position.x < 0 ? true : false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = facingRight ? Vector2.right * speed : Vector2.left * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Empanada"))
        {
            ///compra las empanadas
        }
    }

}
