using System;
using System.Collections.Generic;
using UnityEngine;

public class PattyPool : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> pattyPool = new Queue<GameObject>();
    [SerializeField] private GameObject patty;
    [SerializeField] private int poolSize;

    public static PattyPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject spawnedPatty = Instantiate(patty, new Vector3(100,100,100),Quaternion.identity);
            spawnedPatty.transform.SetParent(transform);
            pattyPool.Enqueue(spawnedPatty);
            spawnedPatty.SetActive(false);
        }
        Debug.Log(pattyPool.Count);   
    }

    public GameObject SpawnPatty(Vector2 position)
    {
        GameObject pattyToSpawn = pattyPool.Dequeue();
        
        pattyToSpawn.SetActive(true);
        pattyToSpawn.transform.position = position;
        
        pattyPool.Enqueue(pattyToSpawn);

        return pattyToSpawn;
    }
}