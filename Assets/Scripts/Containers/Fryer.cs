using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : Container
{
    [SerializeField] private float cookTime;
    [SerializeField] private float burntOutTime;
    
    public override EmpanadaContainer Pickup(GameObject spawnPosition)
    {
        EmpanadaContainer empanada = Empanadas.Dequeue();
        empanada.GetComponent<SpriteRenderer>().enabled = true;
        empanada.gameObject.SetActive(true);
        return empanada;
    }
    
    public override void DropPatty(EmpanadaContainer empanada)
    {
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
