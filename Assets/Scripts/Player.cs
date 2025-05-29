using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement System")]
    [SerializeField] private float speed = 12;
    [SerializeField] private float jumpForce = 30;
    [SerializeField] private LayerMask jumpableLayer;
    [SerializeField] private float detectionDistanceFloor;


    [Header("Attack System")]
    [SerializeField] private float attackRadius = 10;
    [SerializeField] private LayerMask dagamageableLayer;
    [SerializeField] private float attackDamage;
    [SerializeField] private AudioClip clip;

    private Transform foot;
    private Transform attackPoint;
    private Rigidbody2D rb;
    private Animator animator;
    private HealthSystem healthSystem;
    private AudioSource audioSource;
    private float inputH;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        attackPoint = transform.GetChild(1);
        foot = transform.GetChild(2);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }

    void Start()
    {

    }

    void Update()
    {
        Move();
        Jump();
        LauchAttack();
    }

    private void Move()
    {
        animator.SetBool("running", false);
        inputH = Input.GetAxisRaw("Horizontal");
        if (inputH != 0)
        {
            animator.SetBool("running", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }

        rb.linearVelocity = new Vector2(inputH * speed, rb.linearVelocityY);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InFloor())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }

    private bool InFloor()
    {
        return Physics2D.Raycast(foot.position, Vector3.down, detectionDistanceFloor, jumpableLayer);
    }

    private void LauchAttack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("attack");
        }
    }

    //Animation Event
    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, dagamageableLayer);
        foreach (Collider2D enemy in enemies)
        {
            HealthSystem enemyHealthSystem = enemy.gameObject.GetComponent<HealthSystem>();
            enemyHealthSystem.GetDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawSphere(attackPoint.position, attackRadius);
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(clip);
            if (healthSystem.GetLives() <= 0)
            {
                healthSystem.StartDeadAnimation(animator);
            }
        }
    }

}
