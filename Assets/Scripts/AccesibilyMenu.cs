using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccesibilyMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown filterMode;

    private void Update()
    {
        Camera.main.GetComponent<ColorBlindFilter>().mode = (ColorBlindMode)filterMode.value;
        AccesibilityModel.filter = filterMode.value;
    }


}
