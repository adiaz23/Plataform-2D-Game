using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float speedPatrol;

    protected Vector3 actualDestination;
    protected int actualIndex = 0;

    protected virtual void Start(){
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
        Debug.Log($"Destino actual: {actualDestination.x}, Posicion {transform.position.x}");
        if(actualDestination.x < transform.position.x){
            transform.localScale = Vector3.one;
        } else {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }


}
