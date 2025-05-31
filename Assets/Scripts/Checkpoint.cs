using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject[] respawnCollider;
    private BoxCollider2D checkoutCollider;

    void Awake()
    {
        respawnCollider = GameObject.FindGameObjectsWithTag("Respawn");
        checkoutCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            foreach (GameObject respawn in respawnCollider)
            {
                respawn.GetComponent<Respawn>().SpawnPoint = this.gameObject.transform;
            }
            checkoutCollider.enabled = false;
        }
    }
}
