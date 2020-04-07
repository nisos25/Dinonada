using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ThirdContainer : Container
{
    public override void DropPatty(EmpanadaContainer empanada)
    {
        if (empanada == null || empanada.State == EmpanadaState.Raw) return;
        
        Empanadas.Enqueue(empanada);
        empanada.transform.position = transform.position;
        empanada.gameObject.layer = 12;
    }

    public void Clean(int empanadas)
    {
        for (int i = 0; i < empanadas; i++)
        {
            Empanadas.Dequeue().GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
