using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdContainer : Container
{
    public override void DropPatty(EmpanadaContainer empanada)
    {
        if (empanada == null || empanada.State == EmpanadaState.Raw) return;
        
        Empanadas.Enqueue(empanada);
        empanada.gameObject.SetActive(false);
        Debug.Log($"Número de empanadas cocinadas <color=red>{Empanadas.Count}</color>");
    }
}
