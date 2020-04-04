using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imbalance : MonoBehaviour
{
    [SerializeField]
    private float stableSpeed;
    [SerializeField]
    private float stableTime;

    private float yMov;
    private float inactiveTime;

    private void Start()
    {
        StartCoroutine(ChangeValueRotation());
    }

    private void Update()
    {
        //transform.Rotate(0, 0, yMov);
        float zRot = transform.eulerAngles.z;
        zRot = zRot > 180 ? zRot - 360 : zRot;
        zRot = Mathf.Clamp(zRot, -45, 45);
        transform.eulerAngles = Vector3.forward * zRot;

        transform.Rotate(0, 0, yMov + Input.GetAxis("Mouse Y"));

        if(transform.eulerAngles.z == 0)
        {
            StopCoroutine(Estabilize());
            //yMov = Random.Range(-1, 1);
            inactiveTime = Time.time;
        }
        else
        {
            if(inactiveTime <= Time.time + 1)
            {
                StartCoroutine(Estabilize());
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
        yMov = Random.Range(-1f, 1f);
        yield return new WaitForSeconds(stableTime);
        StartCoroutine(ChangeValueRotation());
    }
}