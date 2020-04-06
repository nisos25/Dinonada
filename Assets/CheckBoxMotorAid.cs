using UnityEngine.UI;
using UnityEngine;

public class CheckBoxMotorAid : MonoBehaviour
{
    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Update()
    {
        AccesibilityModel.slowMode = toggle.isOn;
    }
}
