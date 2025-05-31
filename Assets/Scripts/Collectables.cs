using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private CollectableType type;

    [SerializeField] private GameManager gameManager;

    private AudioSource audioSource;

    public enum CollectableType
    {
        Coin,
        Star,
        Gem
    }
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
        if (!other.CompareTag("PlayerHitBox")) return;
        var player = other.GetComponent<Player>();

        switch (type)
        {
            case CollectableType.Coin:
                player.CoinsCollected += 1;
                break;
            case CollectableType.Star:
                player.MaxJumps = 2;
                break;
            case CollectableType.Gem:
                gameManager.Win();
                break;
        }
        OnCollect();
    }

    private void OnCollect()
    {
        audioSource.PlayOneShot(audioSource.clip);
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }
}