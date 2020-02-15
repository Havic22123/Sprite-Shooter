﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipspawner : MonoBehaviour
{
    public GameObject Enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && GameManager.instance.lives > 0)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-11f, 11f);
            randY = Random.Range(-7.52f, -5.7f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
