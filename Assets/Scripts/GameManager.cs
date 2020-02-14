using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject asteroidPrefab;
    public GameObject enemyPrefab;
    public GameObject bullet;
    public static GameManager instance;
    public int lives = 3;
    public int score = 0;
    public bool isPaused = false;
    public List<GameObject> enemiesList = new List<GameObject>();
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // This is just for demonstration.
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if (player == null)
            //{
            //    Respawn();
            //}

            Instantiate(asteroidPrefab);

            
        }

        if (CanSpawnEnemy())
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // TODO: Enemies appear at a random Spawn Point
        // TODO: The enemy spawned is a random asteroid or enemy ship
        // The types of enemies spawned are prefabs stored in a list that can be edited by designers. (enemyPrefabs)
        // It may help to reference Lecture 6.2b - UnityEngine.Random
        // URL: https://uat.instructure.com/courses/2847/pages/lecture-6-dot-2b-unityengine-dot-random?module_item_id=259068
        throw new NotImplementedException();
    }

    private bool CanSpawnEnemy()
    {
        // TODO: Return true if there are less than 3 enemies spawned, otherwise return false.
        // It may help to reference the documentation for the List class. The Count property will be useful.
        // Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.8
        throw new NotImplementedException();
    }

    public void Respawn()
    {
        player = Instantiate(playerPrefab);
    }


    public void Die()
    {
        // TODO: Destroy all enemies before spawning the player.
        // The ForEach method from the List class may be useful here.
        // Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.foreach?view=netframework-4.8
        lives -= 1;
        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            Debug.Log("Game Over");
            Application.Quit();
        }
    }
}
