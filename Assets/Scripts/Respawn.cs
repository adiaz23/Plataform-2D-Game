using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            other.gameObject.transform.position = SpawnPoint.transform.position;
        }
    }
}
