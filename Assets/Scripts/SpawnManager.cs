using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPosition = new Vector3 (25, 0, 0);
    private IEnumerator coroutine;
    //public float startDelay = 2f;
    //public float repeatRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnObstacles();
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if(!GameController.gameOver) CreateObstacle();
            yield return new WaitForSeconds(GameController.TimeToSpawn);
        }
    }

    private void CreateObstacle()
    {
        GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length-1)];
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
