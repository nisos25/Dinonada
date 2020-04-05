using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int buenas;
    int quemadas;

    void SetEmpanadas(int bien, int quemadeichon)
    {
        buenas = bien;
        quemadas = quemadeichon;
    }

    void CreateEmpanadas()
    {
        //InstanciarEmpanadas
    }
}
