using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private PickUp _pickUpPrefab;
    [SerializeField] private float _spawnInterval;
    
    private Transform[] _spawnPoints;
    private PickUp[] _currentPickUps;
    private void Start()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>(false);

        _spawnPoints = new Transform[allChildren.Length - 1];
        for (int i = 1; i < allChildren.Length; i++)
        {
            _spawnPoints[i - 1] = allChildren[i];
        }

        _currentPickUps = new PickUp[_spawnPoints.Length];
        
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            SpawnCoin(i);
        }
    }

    public void RespawnPickUp(int index)
    {
        StartCoroutine(RespawnAfterDelay(index, _spawnInterval));
    }
    
    private IEnumerator RespawnAfterDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnCoin(index);
    }

    private void SpawnCoin(int index)
    {
        PickUp coin = Instantiate(_pickUpPrefab, _spawnPoints[index].position, Quaternion.identity);
        _currentPickUps[index] = coin;

        PickUp pickup = coin.GetComponent<PickUp>();
        pickup.SetSpawner(this, index);
    }
}
