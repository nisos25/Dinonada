using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner: MonoBehaviour
{
    [SerializeField]
    float secondsToSpawn;

    Vector2 spawnPositions;
    /// <summary>
    /// La posición en Y del spawner
    /// </summary>
    [SerializeField]
    float yPos;
    /// <summary>
    /// Sensibilidad/Aleatoridad en la posición de spawn en Y
    /// </summary>
    [SerializeField]
    float ySensib;


    [SerializeField]
    GameObject[] people;

    private float[] xPositions;

    void Start()
    {
        spawnPositions = ScreenSize();
        //Debug.Log(spawnPositions);
        StartCoroutine(Spawn());
    }

    
    private Vector2 ScreenSize()
    {
        Camera camera = Camera.main;
        Vector3 bottomLeftWorld = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRightWorld = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        float[] positionsX = { -topRightWorld.x, topRightWorld.x };
        xPositions = positionsX;
        return new Vector2(topRightWorld.x, topRightWorld.y);

    }

    IEnumerator Spawn()
    {
        int[] ran = { -1, 1 };
        int ranPeople = Random.Range(0,people.Length); 
        Instantiate(people[ranPeople],
            new Vector2(xPositions[Random.Range(0,
                        xPositions.Length)],
                        Random.Range(-2,2))
                        ,Quaternion.identity
            );
        yield return new WaitForSeconds(secondsToSpawn);
        StartCoroutine(Spawn());
    }

}