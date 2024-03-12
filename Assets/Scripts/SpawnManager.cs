using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float _spawnRange = 9f;
    public int waveNumber = 0;
    public int enemyCount;

    void Start(){
        NewEnemyWave();
    }

    void Update(){
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount <= 0){
            NewEnemyWave();
        }
    }

    void NewEnemyWave(){
        waveNumber++;
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for(int i=0; i < enemiesToSpawn; i++)
            SpawnEnemy();
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void SpawnPowerUp(){
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition(){
        return new Vector3(Random.Range(-_spawnRange, _spawnRange), 0f, Random.Range(-_spawnRange, _spawnRange));
    }
}
