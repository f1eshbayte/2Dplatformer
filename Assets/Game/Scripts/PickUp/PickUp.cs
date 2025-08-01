using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PickUpSpawner _spawner;
    private int _spawnIndex;

    public void SetSpawner(PickUpSpawner spawner, int index)
    {
        _spawner = spawner;
        _spawnIndex = index;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            _spawner.RespawnPickUp(_spawnIndex);
            Destroy(gameObject);
        }
    }   
}