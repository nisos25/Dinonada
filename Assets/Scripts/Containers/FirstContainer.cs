using UnityEngine;
using Random = UnityEngine.Random;

public class FirstContainer : Container
{
    public override int Iterator
    {
        get => Random.Range(4, 7);
        protected set => Iterator = value;
    }

    public override EmpanadaContainer Pickup(GameObject spawnPosition)
    {
        GameObject patty = PattyPool.Instance.SpawnPatty(spawnPosition.transform.position);
        GetComponentInChildren<Animator>().SetTrigger("wasUsed");    
        EmpanadaContainer empanada = patty.GetComponent<EmpanadaContainer>();
        return empanada;
    }
}
