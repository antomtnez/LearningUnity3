using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float _spawnRange = 9f;

    void Start(){
        SpawnEnemy();
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition(){
        return new Vector3(Random.Range(-_spawnRange, _spawnRange), 0f, Random.Range(-_spawnRange, _spawnRange));
    }
}
