using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemSpawner _spawner;
    private int _spawnIndex;

    public void SetSpawner(ItemSpawner spawner, int index)
    {
        _spawner = spawner;
        _spawnIndex = index;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _spawner.RespawnPickUp(_spawnIndex);
            Destroy(gameObject);
        }
    }   
}