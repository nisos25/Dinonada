using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPicker : MonoBehaviour
{
    [SerializeField] private Transform rightArm;
    [SerializeField] private Transform leftArm;
    [SerializeField] private GameObject pattySpawnPosition;
    
    private bool armsClosed;
    private List<EmpanadaContainer> empanadas = new List<EmpanadaContainer>();
    private Container container;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CloseArms();
        }
        else
        {
            OpenArms();
        }
    }

    private void OpenArms()
    {
        if (!armsClosed) return;
        
        armsClosed = false;
        OpenArm(rightArm);
        OpenArm(leftArm);

        if (container != null)
        {
            foreach (var empanada in empanadas)
            {
                container.DropPatty(empanada);
            }
        }
        
        empanadas.Clear();
    }
    
    private void CloseArms()
    {
        if (armsClosed) return;
        
        armsClosed = true;
        CloseArm(rightArm);
        CloseArm(leftArm);

        if (container != null)
        {
            for (int i = 0; i <= container.Iterator; i++)
            {
                empanadas.Add(container.Pickup(pattySpawnPosition));
            }
        }
    }

    private void CloseArm(Transform arm)
    {
        var position = arm.localPosition;
        position = new Vector3(position.x - position.x/4, position.y);
        arm.localPosition = position;
    }

    private void OpenArm(Transform arm)
    {
        var position = arm.localPosition;
        position = new Vector3(position.x + position.x/3, position.y);
        arm.localPosition = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        container = other.GetComponent<Container>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Container>())
        {
            container = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EmpanadaContainer empanadaContainer = other.gameObject.GetComponent<EmpanadaContainer>();
        
        if (empanadaContainer != null && armsClosed)
        {
            if (!empanadas.Contains(empanadaContainer))
            {
                empanadas.Add(empanadaContainer);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        EmpanadaContainer empanadaContainer = other.gameObject.GetComponent<EmpanadaContainer>();
        
        if (empanadaContainer != null)
        {
            empanadas.Remove(empanadaContainer);
        }
    }
}