﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float bossClock = 30.0f;
    public float aSetClock = 8.0f;
    public float bSetClock = 12.0f;

    public GameObject bossA;
    public Transform bossSpawn;

    public GameObject enemyA;
    public Transform[] spawnA;

    public GameObject enemyB;
    public Transform[] spawnB;

    public float aClock;
    public float bClock;

    public Text scoreBoard;
    private float score = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnA());
        aClock = aSetClock;
        bClock = bSetClock;

    }
	
	// Update is called once per frame
	void Update () {
        //scoreBoard.text = score.ToString();
        if (bossClock > 0)
        {
            bossClock -= Time.deltaTime;
		    if (bossClock < 0)
            {
                StartCoroutine(SpawnBoss());
                
            }
        }


        if (aClock > 0 && bossClock > 0)
        {
            aClock -= Time.deltaTime;
            if (aClock < 0)
            {
                StartCoroutine(SpawnA());
                aClock = aSetClock;
            }
        }

        if (bClock > 0 && bossClock > 0)
        {
            bClock -= Time.deltaTime;
            if (bClock < 0)
            {
                StartCoroutine(SpawnB());
                bClock = bSetClock;
            }
        }

    }


    public void updateScore(int value)
    {
        score += value;
    }

    public void mulScore()
    {
        score *= 2;
    }

    public void endGame()
    {
        StartCoroutine(fnishScene());
        
    }

    IEnumerator SpawnA()
    {
        yield return new WaitForSeconds(0);
        int spawnPointIndex = Random.Range(0, spawnA.Length);
        var enemy = (GameObject)Instantiate(enemyA, spawnA[spawnPointIndex].position, spawnA[spawnPointIndex].rotation);
    }
    IEnumerator SpawnB()
    {
        yield return new WaitForSeconds(0);
        int spawnPointIndex = Random.Range(0, spawnB.Length);
        var enemy = (GameObject)Instantiate(enemyB, spawnB[spawnPointIndex].position, spawnB[spawnPointIndex].rotation);
    }
    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(10);
        var boss = (GameObject)Instantiate(bossA, bossSpawn.position, bossSpawn.rotation);

    }
    IEnumerator fnishScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

}