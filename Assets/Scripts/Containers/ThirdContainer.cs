using System.Collections;
using System.Collections.Generic;
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
}
