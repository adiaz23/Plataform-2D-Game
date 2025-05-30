using System.Collections;
using UnityEngine;
using UnityEngine.Lumin;

public class Platform : MonoBehaviour
{

    [Header("Movement System")]
    [SerializeField] protected Transform[] points;
    [SerializeField] protected float speed;

    protected Vector3 actualDestination;
    private Vector3 lastPosition;
    protected int actualIndex = 0;

    private Transform playerOnPlatform;

    void Start()
    {
        actualDestination = points[actualIndex].position;
        lastPosition = transform.position;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            float steps = speed * Time.deltaTime;
            Vector3 previousPosition = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, actualDestination, steps);

            Vector3 platformVelocity = transform.position - previousPosition;

            if (playerOnPlatform != null)
            {
                playerOnPlatform.position += platformVelocity;
            }

            if (transform.position == actualDestination)
            {
                SetNewDestination();
            }

            yield return null;
        }
    }

    private void SetNewDestination()
    {
        actualIndex++;
        if (actualIndex >= points.Length)
        {
            actualIndex = 0;
        }
        actualDestination = points[actualIndex].position;
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            playerOnPlatform = other.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            playerOnPlatform = null;
    }
}
