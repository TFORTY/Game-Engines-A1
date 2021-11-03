using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusSpawner : Spawner
{
    protected override void spawnPlanet()
    {
        Vector3 position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x + spawnOffset, Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        var planet = UranusPool.Instance.GetFromPool();
        planet.transform.position = position;
    }
}