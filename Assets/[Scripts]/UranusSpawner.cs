using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusSpawner : MonoBehaviour
{
    // Spawner attributes
    [SerializeField]
    private GameObject planetPrefab;

    public float respawnTime = 1f;
    public float spawnLocation = -10f;
    public float minY = 0f;
    public float maxY = 0f;
    public float minZ = 0f;
    public float maxZ = 0f;
    private Vector3 screenBounds;

    public GameObject player;
    public float spawnOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(planetWave());
    }

    private void spawnPlanet()
    {
        Vector3 position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x + spawnOffset, Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        var planet = UranusPool.Instance.GetFromPool();
        planet.transform.position = position;
    }

    IEnumerator planetWave()
    {
        // Spawns planets at every interval
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPlanet();
        }
    }
}
