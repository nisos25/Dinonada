using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    protected Queue<EmpanadaContainer> Empanadas { get; set; } = new Queue<EmpanadaContainer>();

    public virtual int Iterator
    {
        get => Empanadas.Count;
        protected set => Iterator = value;
    }

    public virtual void DropPatty(EmpanadaContainer empanada)
    {
        Debug.LogWarning("No se pueden soltar empanadas en el contenedor");
    }

    public virtual EmpanadaContainer Pickup(GameObject spawnPosition)
    {
        Debug.LogWarning("No se pueden agarrar empanadas del contenedor");
        return null;
    }

}