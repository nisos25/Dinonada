using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : Container
{
    [SerializeField] private float cookTime;
    [SerializeField] private float burntOutTime;
    
    public override EmpanadaContainer Pickup(GameObject spawnPosition)
    {
        for (int i = 0; i < Empanadas.Count; i++)
        {
            EmpanadaContainer empanada = Empanadas.Peek();
            if (empanada.State != EmpanadaState.Raw)
            {
                Empanadas.Dequeue();
                empanada.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                empanada.gameObject.SetActive(true);
                empanada.GetComponent<SpriteRenderer>().enabled = true;
                empanada.transform.position = spawnPosition.transform.position;
                StopAllCoroutines();
                return empanada;
            }    
        }
        return null;
    }
    
    public override void DropPatty(EmpanadaContainer empanada)
    {
        if (empanada == null) return;
        
        Empanadas.Enqueue(empanada);
        empanada.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Fry(empanada));
    }
    
    
    private IEnumerator Fry(EmpanadaContainer empanada)
    {
        yield return new WaitForSeconds(cookTime);
        empanada.State = EmpanadaState.Cooked;
        yield return new WaitForSeconds(burntOutTime);
        empanada.State = EmpanadaState.Burnt;
        empanada.gameObject.SetActive(false);
    }
}
