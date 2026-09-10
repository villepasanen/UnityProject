using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Tilemap _groundTiles;
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _spawnCooldown;
    [SerializeField] float _spawnCooldownReductionMultiplier;
    [SerializeField]List<Enemy> _enemyList;
    [SerializeField] float _minimumSpawnDistance;
    [SerializeField] Transform _player;
    float _currentCooldown;
    
    List<Vector3> _spawnPositions = new();
    void SetEnemySpawnPositions()
    {
        foreach(Vector3Int position in _groundTiles.cellBounds.allPositionsWithin){

            if (_groundTiles.HasTile(position))
            {
                Vector3 spawnPosition = _groundTiles.GetCellCenterWorld(position);
                float distance = Vector3.Distance(spawnPosition, _player.position);
                if(distance >= _minimumSpawnDistance)
                {
                    _spawnPositions.Add(_groundTiles.GetCellCenterWorld(position));
                }
              

            }
        }
    }
    
    void Start()
    {
        SetEnemySpawnPositions();
        InvokeRepeating(nameof(HandleGameDifficultyIncrease), 1f, 1f);
    }

    
    void Update()
    {
        HandleEnemySpawning();
        
    }
    void HandleEnemySpawning()
    {
        _currentCooldown -= Time.deltaTime;
        if(_currentCooldown > Time.time)
        {
            return;
        }
        _currentCooldown = Time.time + _spawnCooldown;
        SpawnEnemyRandomLocation();
    }
    Vector3 GetRandomPosition()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)];
    }
    void SpawnEnemyRandomLocation()
    {
        int rand = Random.Range(0, _enemyList.Count);
        Instantiate(_enemyList[rand], GetRandomPosition(), Quaternion.identity);
    }
    void HandleGameDifficultyIncrease()
    {
        _spawnCooldown *= _spawnCooldownReductionMultiplier;
    }
}
