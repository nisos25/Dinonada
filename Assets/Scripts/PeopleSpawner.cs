using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner: MonoBehaviour
{
    [SerializeField]
    float secondsToSpawn;
    [SerializeField]
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

    // Start is called before the first frame update
    void Start()
    {
        spawnPositions = ScreenSize();
        StartCoroutine(Spawn());
    }

    
    private Vector2 ScreenSize()
    {
        Camera camera = Camera.main;
        Vector3 bottomLeftWorld = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRightWorld = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        return new Vector2(topRightWorld.x, topRightWorld.y);
    }

    IEnumerator Spawn()
    {
        int ranPeople = Random.Range(0,people.Length); 
        Instantiate(people[ranPeople],spawnPositions,Quaternion.identity);
        yield return new WaitForSeconds(secondsToSpawn);
    }

}