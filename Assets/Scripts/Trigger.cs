using UnityEngine;

public class Trigger : MonoBehaviour
{

    private AudioSource audioSource;
    private CircleCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            SetDoubleJump(other);
        }
    }

    void SetDoubleJump(Collider2D other)
    {
        other.gameObject.GetComponent<Player>().MaxJumps = 2;
        audioSource.PlayOneShot(audioSource.clip);
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    void SetPoints(Collider2D other)
    {
        
    }
}
