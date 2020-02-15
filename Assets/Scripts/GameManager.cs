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
    public static void DestroyGameObjectsWithTag(string Hazzard)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Hazzard);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
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
        Destroy(GameObject.FindWithTag("Hazzard"));
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
