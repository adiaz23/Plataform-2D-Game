using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int playerDamge;

    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            other.gameObject.GetComponent<HealthSystem>().GetDamage(playerDamge);
            other.gameObject.transform.position = SpawnPoint.transform.position;
        }
    }
}
