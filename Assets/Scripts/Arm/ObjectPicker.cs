using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPicker : MonoBehaviour
{
    [SerializeField] private Transform rightArm;
    [SerializeField] private Transform leftArm;
    [SerializeField] private GameObject pattySpawnPosition;
    
    private bool armsClosed;

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
    }
    
    private void CloseArms()
    {
        if (armsClosed) return;
        
        armsClosed = true;
        CloseArm(rightArm);
        CloseArm(leftArm);
        
        for (int i = 0; i < Random.Range(4,7); i++)
        {
            PattyPool.Instance.SpawnPatty(pattySpawnPosition.transform.position);
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
        
    }
}