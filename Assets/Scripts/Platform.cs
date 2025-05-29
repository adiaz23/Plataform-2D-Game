using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [Header("Movement System")]
    [SerializeField] protected Transform[] points;
    [SerializeField] protected float speed;

    protected Vector3 actualDestination;
    protected int actualIndex = 0;
    void Start()
    {
        actualDestination = points[actualIndex].position;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float steps = speed * Time.deltaTime;
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
        if (actualIndex >= points.Length)
        {
            actualIndex = 0;
        }
        actualDestination = points[actualIndex].position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            other.gameObject.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            other.gameObject.transform.parent = null;
    }
}
