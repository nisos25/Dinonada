using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(AudioSource))]
public class Empanada : MonoBehaviour
{
    Transform parent;
    Rigidbody2D rb;
    AudioSource audioSource;

    [SerializeField]
    AudioClip splat;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < parent.position.y-0.5f)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            Destroy(rb);
            audioSource.PlayOneShot(splat);
            transform.parent = null;
            Destroy(GetComponent<Empanada>());
        }
    }
}
