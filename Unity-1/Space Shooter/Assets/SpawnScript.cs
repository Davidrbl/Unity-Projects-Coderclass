using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject enemyPrefab;

    private float nextTimeToSpawn = 0f;

    public bool playerAlive = false;

    void Start()
    {

    }

    void Update()
    {
      if (Time.time >= nextTimeToSpawn && playerAlive)
      {
        Vector2 startPos = new Vector2(Random.Range((float)-8.5, (float)8.5), 7);
        Instantiate(enemyPrefab, startPos, Quaternion.identity);
        nextTimeToSpawn = Time.time + 1f / spawnRate;
      }
    }
}﻿
