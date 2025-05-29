using System.Collections;
using Mono.Cecil.Cil;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float speedPatrol;
    
    [Header("Attack System")]
    [SerializeField] protected float attackDamage;

    [SerializeField] protected LayerMask dagamageableLayer;

    [SerializeField] protected float attackRadius;

    [SerializeField] protected Transform attackPoint;


    protected Vector3 actualDestination;
    protected int actualIndex = 0;

    protected bool canFollowPlayer = true;

    protected virtual void Start()
    {
        actualDestination = patrolPoints[actualIndex].position;
        StartCoroutine(Patrol());
    }

    protected IEnumerator Patrol()
    {
        float steps = speedPatrol * Time.deltaTime;
        while (gameObject)
        {
            while (transform.position != actualDestination)
            {
                transform.position = Vector3.MoveTowards(transform.position, actualDestination, steps);
                yield return null;
            }
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        actualIndex++;
        if (actualIndex >= patrolPoints.Length)
        {
            actualIndex = 0;
        }
        actualDestination = patrolPoints[actualIndex].position;
        RotateToDestination(actualDestination);
    }

    private void RotateToDestination(Vector3 actualPosition)
    {
        if (actualPosition.x < transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    private IEnumerator FollowPlayer(Collider2D player)
    {
        while (gameObject && player != null)
        {
            float steps = speedPatrol * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, steps);
            RotateToDestination(player.transform.position);
            yield return null;
        }
    }

    protected abstract void LaunchAttack();

    //Animation event
    protected virtual void Attack()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRadius, dagamageableLayer);
        if (player != null)
        {
            HealthSystem healthSystem = player.GetComponent<HealthSystem>();
            healthSystem.GetDamage(attackDamage);
        }

    }

    //Animation event
    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDetection"))
        {
            StopAllCoroutines();
            StartCoroutine(FollowPlayer(other));
        }
        else if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            LaunchAttack();
        }
    }
    
    private void OnDrawGizmos()
    {
        if(transform.position != null)
            Gizmos.DrawSphere(attackPoint.position, attackRadius);
    }

}
