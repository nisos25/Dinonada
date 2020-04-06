using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEndScene : MonoBehaviour
{
   private void Start()
    {
        GetComponent<Animator>().SetTrigger("happy");
    }
}
