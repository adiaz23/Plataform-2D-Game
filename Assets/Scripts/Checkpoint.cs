using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn respawnCollider;
    private BoxCollider2D checkoutCollider;

    void Awake()
    {
        respawnCollider = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
        checkoutCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            respawnCollider.SpawnPoint = this.gameObject.transform;
            checkoutCollider.enabled = false;
        }
    }
}
