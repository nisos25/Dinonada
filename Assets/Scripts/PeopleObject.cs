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
    [SerializeField]
    private GameObject pensamiento;
    [SerializeField]
    private AudioClip coin;
    [SerializeField]
    private AudioClip caching;

    public bool special;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        audioSource = GetComponent<AudioSource>();
        pensamiento = transform.GetChild(0).gameObject;
        facingRight = transform.position.x < 0 ? true : false;
        GetComponent<SpriteRenderer>().flipX = facingRight;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        if(special)
        {
            cantidadEmpanadas = 5;
            speed = 4;
            ///sonido especial
        }
        else
        {
            RandomParameters();
            StartCoroutine(Timer());
        } 

    }

    // Update is called once per frame
    void FixedUpdate()
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
            if(cantidadEmpanadas>0)
            {
                Destroy(collision.gameObject);
                ReduceEmpanadasQuantity();
                ///Vender
            }
        }
    }

    void ReduceEmpanadasQuantity()
    {
        cantidadEmpanadas--;
        ///sonido moneda
        audioSource.PlayOneShot(coin);
        if(cantidadEmpanadas <= 0)
        {
            ///Sonido caching
            audioSource.PlayOneShot(caching);
            DeactivateInterestInEmpanadas();
        }
    }

    void RandomParameters()
    {
        cantidadEmpanadas = Random.Range(0,4);
        //speed += Random.Range(-1,1);
        if(cantidadEmpanadas > 0)
        {
            pensamiento.SetActive(true);

            timepoInteresado = Random.Range(4,10);
        }
        else
        {
            DeactivateInterestInEmpanadas();
        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        timepoInteresado--;
        if(timepoInteresado <= 0)
        {
            DeactivateInterestInEmpanadas();
            StopCoroutine(Timer());
        }
    }

    void DeactivateInterestInEmpanadas()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
