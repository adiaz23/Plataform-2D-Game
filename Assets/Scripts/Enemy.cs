using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float speedPatrol;
    [SerializeField] protected float attackDamage;

    protected Vector3 actualDestination;
    protected int actualIndex = 0;

    protected bool canFollowPlayer = true;

    protected virtual void Start()
    {
        actualDestination = patrolPoints[actualIndex].position;
        StartCoroutine(Patrol());
    }

    protected IEnumerator Patrol(){
        float steps = speedPatrol * Time.deltaTime;
        while(gameObject){
            while(transform.position != actualDestination){
                transform.position = Vector3.MoveTowards(transform.position, actualDestination, steps);
                yield return null;
            }
            SetNewDestination();
        }                
    }

    private void SetNewDestination(){
        actualIndex++;
        if(actualIndex >= patrolPoints.Length){    
            actualIndex = 0;
        }
        actualDestination = patrolPoints[actualIndex].position;
        RotateToDestination();
    }

    private void RotateToDestination(){
        if(actualDestination.x < transform.position.x){
            transform.localScale = Vector3.one;
        } else {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    private IEnumerator FollowPlayer(Collider2D player){  
        while (gameObject && player != null){
            float steps = speedPatrol * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, steps);
            yield return null;
        }
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
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            healthSystem.GetDamage(attackDamage);
        }
    }

}
