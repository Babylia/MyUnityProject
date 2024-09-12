using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<Transform> RespawnPoints = new List<Transform>();
    [SerializeField] GameObject Enemy;
    [SerializeField,Range(1,20)] float TimeToResp;
    [SerializeField] Slider SpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer.maxValue = TimeToResp;
        SpawnTimer.minValue = 0;
        SpawnTimer.value = 0;
        InvokeRepeating(nameof(SpawnEnemy),TimeToResp,TimeToResp);
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer.value += Time.deltaTime;
    }
    void SpawnEnemy()
    {
        Vector3 RandSpawn = RespawnPoints[Random.Range(0, RespawnPoints.Count)].position;
        Vector3 spawn = new Vector3(RandSpawn.x, RandSpawn.y + Enemy.transform.localScale.y, RandSpawn.z);
        Instantiate(Enemy, spawn, Quaternion.identity);
        SpawnTimer.value = 0;
    }
}
