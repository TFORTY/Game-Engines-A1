using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1f;
    public float spawnLocation = -10f;
    public float minY = 0f;
    public float maxY = 0f;
    public float minZ = 0f;
    public float maxZ = 0f;
    private Vector3 screenBounds;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector3(screenBounds.x * spawnLocation + player.transform.position.x, Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    IEnumerator asteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }  
    }
}