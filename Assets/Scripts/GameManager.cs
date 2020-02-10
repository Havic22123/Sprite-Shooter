using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject asteroidPrefab;
    public int score = 0;
    public bool isPaused = false;
    public GameObject playerPrefab;
    public int lives = 3;
    public GameObject killboxPrefab;
    public List<GameObject> EnemiesList = new List<GameObject>();
    public GameObject player;

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
    }

    public void Respawn()
    {
            player = Instantiate(playerPrefab);
    }

    public void killRespawn()
    {
        Instantiate(killboxPrefab);
    }
}
