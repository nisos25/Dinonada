using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : Container
{
    [SerializeField] private float cookTime;
    [SerializeField] private float burntOutTime;
    [SerializeField] private Animator fryPotAnimator;
    [SerializeField] private Animator smokeAnimator;

    private List<EmpanadaContainer> burntEmpanadas = new List<EmpanadaContainer>();
   
    
    private void Update()
    {
        if (burntEmpanadas.Count <= 0)
        {
            smokeAnimator.SetBool("Burning",false);
        }

        for (int i = 0; i < Empanadas.Count; i++)
        {
            EmpanadaContainer empanada = Empanadas.Peek();

            if (empanada.State == EmpanadaState.Raw)
            {
                smokeAnimator.SetBool("isFrying",false);
                fryPotAnimator.SetBool("isFrying",false);
                return;
            }
            
            smokeAnimator.SetBool("isFrying",true);
            fryPotAnimator.SetBool("isFrying",true);
        }
    }

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
                //StopCoroutine();
                
                if (burntEmpanadas.Contains(empanada))
                {
                    burntEmpanadas.Remove(empanada);
                }
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
        if (empanada.State == EmpanadaState.Raw)
        {
            fryPotAnimator.SetBool("isFrying",true);
            yield return new WaitForSeconds(cookTime);
            smokeAnimator.SetBool("isFrying",true);
            empanada.State = EmpanadaState.Cooked;    
        }
        
        if (empanada.State == EmpanadaState.Cooked)
        {
            yield return new WaitForSeconds(burntOutTime);
            
            if (!Empanadas.Contains(empanada))
            {
                yield break;
            }
            
            smokeAnimator.SetBool("Burning",true);
            burntEmpanadas.Add(empanada);
            empanada.State = EmpanadaState.Burnt;    
        }
        
        
        empanada.gameObject.SetActive(false);
    }
}
