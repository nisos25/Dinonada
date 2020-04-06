using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]
public class Empanada : MonoBehaviour
{
    Transform parent;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < parent.position.y-0.5f)
        {
            transform.parent = null;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            Destroy(rb);
            Destroy(GetComponent<Empanada>());
        }
    }
}
