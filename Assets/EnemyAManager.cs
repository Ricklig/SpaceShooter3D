using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAManager : MonoBehaviour {
    
    public GameObject enemyPrefab;

    public int alive = 5;
    bool bns = true;
    bool spawnOver = false;
    public GameObject bonusDrop;


    Vector3 position;

    // Use this for initialization
    void Start()
    {

        StartCoroutine(Spawn());
    }

    public void noBonus()
    {
        bns = false;
    }

    public void sendPos(Vector3 pos)
    {
        position = pos;
    }

    void Update()
    {
        if (spawnOver)
        {
            alive = gameObject.transform.childCount;
        }

        if (alive == 0)
        {
            if (bns)
            {
                var bonus = (GameObject)Instantiate(bonusDrop, position, gameObject.transform.rotation);
                GameObject.FindWithTag("GameController").GetComponent<GameManager>().mulScore();
            }
            Destroy(gameObject);
        }

    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0);
        var enemy = (GameObject)Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        enemy.transform.parent = transform;
        Vector3 a2 = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z + 2);
        var enemy1 = (GameObject)Instantiate(enemyPrefab, a2, gameObject.transform.rotation);
        enemy1.transform.parent = transform;
        Vector3 a3 = new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y, gameObject.transform.position.z + 2);
        var enemy2 = (GameObject)Instantiate(enemyPrefab, a3, gameObject.transform.rotation);
        enemy2.transform.parent = transform;
        Vector3 a4 = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z + 4);
        var enemy3 = (GameObject)Instantiate(enemyPrefab, a4, gameObject.transform.rotation);
        enemy3.transform.parent = transform;
        Vector3 a5 = new Vector3(gameObject.transform.position.x - 4, gameObject.transform.position.y, gameObject.transform.position.z + 4);
        var enemy4 = (GameObject)Instantiate(enemyPrefab, a5, gameObject.transform.rotation);
        enemy4.transform.parent = transform;
        spawnOver = true;


    }


}
