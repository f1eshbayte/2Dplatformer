using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item pick))
        {
            _audio.PlayOneShot(_audio.clip);
        }
    }
}
