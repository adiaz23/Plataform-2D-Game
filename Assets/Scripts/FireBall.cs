using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] private float shootImpulse;
    [SerializeField] private int playerDamege;
    private Rigidbody2D rb;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootImpulse, ForceMode2D.Impulse);
    }

    public void EndExplosion()
    {
        Destroy(gameObject);
    } 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();
            healthSystem.GetDamage(playerDamege);
            animator.SetTrigger("explote");
        }
    }
}
