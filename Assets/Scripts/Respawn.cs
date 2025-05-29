using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
