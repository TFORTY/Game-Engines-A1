using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner
{
    protected override void spawnPlanet()
    {
        Vector3 position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x + spawnOffset, Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        var planet = AsteroidPool.Instance.GetFromPool();
        planet.transform.position = position;
    }
}