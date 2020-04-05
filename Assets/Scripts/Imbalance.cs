using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imbalance : MonoBehaviour
{
    [SerializeField]
    private float stableSpeed;
    [SerializeField]
    private float stableTime;
    [SerializeField]
    private int maxAngle;
    [SerializeField]
    private float randRangeRotation;

    private float yMov;
    private float inactiveTime;



    private void Start()
    {
        StartCoroutine(ChangeValueRotation());
    }

    private void Update()
    {
        float zRot = transform.eulerAngles.z;
        zRot = zRot > 180 ? zRot - 360 : zRot;
        zRot = Mathf.Clamp(zRot, -maxAngle, maxAngle);
        transform.eulerAngles = Vector3.forward * zRot;

        transform.Rotate(0, 0, yMov + Input.GetAxis("Mouse X"));

        if(transform.eulerAngles.z == 0)
        {
            StopCoroutine(Estabilize());
            inactiveTime = Time.time;
        }
        else
        {
            if(inactiveTime <= Time.time + 1)
            {
                //StartCoroutine(Estabilize());
            }
        }
    }

    IEnumerator Estabilize()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), stableSpeed * Time.deltaTime);
        yield return null;
    }

    IEnumerator ChangeValueRotation()
    {
        yMov = Random.Range(-randRangeRotation, randRangeRotation);
        yield return new WaitForSeconds(stableTime);
        StartCoroutine(ChangeValueRotation());
    }
}