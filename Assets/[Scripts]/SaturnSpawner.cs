using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnSpawner : MonoBehaviour
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
        //lastTime = Time.time;

        Vector3 position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x + spawnOffset, Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        var planet = SaturnPool.Instance.GetFromPool();
        planet.transform.position = position;

        // Spawn a planet at a random y and z while making sure they start to spawn away from the player
        //GameObject a = Instantiate(planetPrefab) as GameObject;
        //a.transform.position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x + spawnOffset, Random.Range(minY, maxY), Random.Range(minZ, maxZ));
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