using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEndScene : MonoBehaviour
{
    public bool state;

   private void Start()
    {
        if(!state)GetComponent<Animator>().SetTrigger("happy");
        else GetComponent<Animator>().SetTrigger("sad");
    }
}
