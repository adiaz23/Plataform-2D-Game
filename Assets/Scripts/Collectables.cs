using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private CollectableType type;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private int livesRestored = 10;

    private AudioSource audioSource;

    public enum CollectableType
    {
        Coin,
        Star,
        Gem,
        Potion
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
        HealthSystem playerHealth = other.GetComponent<HealthSystem>();

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
            case CollectableType.Potion:
                playerHealth.RestoreHealth(livesRestored);
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