using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spwanPoints;
    public GameObject enemyPrefab, enemies;

    public float enemyBurstCount=3, spawnTime = 1;

    Transform location;
    float updateTime;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
            spwanPoints.Add(child);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > updateTime){
            updateTime = Time.time + spawnTime;
            SpwanEnemy();
        }
        
    }

    public void SpwanEnemy(){
        if(enemies.transform.childCount < enemyBurstCount){
        location = spwanPoints[Random.Range(0, transform.childCount)];
        var enemyInstance = Instantiate(enemyPrefab, location);
        enemyInstance.transform.SetParent(enemies.transform);
        enemyInstance.transform.LookAt(Vector3.zero);
        }
    }
}
