using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    [SerializeField]
    private float _spawnRate;
    [SerializeField]
    private float _maxX;
    [SerializeField]
    private float _maxZ;
    [SerializeField]
    private float _minX;
    [SerializeField]
    private float _minZ;
    [SerializeField]
    private float _minSize;
    [SerializeField]
    private float _maxSize;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _powerUpPrefab;
    [SerializeField]
    private float _powerUpSpawnRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(PowerUpSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawn()
    {
        while (_gameManager.GetIsGameOver == false)
        {
            int randomIndex = Random.Range(0, foodPrefabs.Length);
            yield return new WaitForSeconds(_spawnRate);
            float randomX = Random.Range(_minX, _maxX);
            float randomZ = Random.Range(_minZ, _maxZ);
            float randomSize = Random.Range(_minSize, _maxSize);
            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);
            GameObject food = Instantiate(foodPrefabs[randomIndex], spawnPosition, foodPrefabs[randomIndex].transform.rotation);
            food.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        }
    }

    IEnumerator PowerUpSpawner()
    {
        while (_gameManager.GetIsGameOver == false)
        {
            yield return new WaitForSeconds(_powerUpSpawnRate);
            float randomX = Random.Range(_minX, _maxX);
            float randomZ = Random.Range(_minZ, _maxZ);
            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);
            GameObject powerUp = Instantiate(_powerUpPrefab, spawnPosition, _powerUpPrefab.transform.rotation);
        } 
    }
}
