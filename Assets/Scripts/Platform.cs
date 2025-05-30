using System.Collections;
using UnityEngine;
using UnityEngine.Lumin;

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
        {
            StartCoroutine(SafeParent(other.transform));
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            if (other.transform.parent == transform)
                other.transform.SetParent(null, true);
    }

    private IEnumerator SafeParent(Transform target)
    {
        yield return null;

        if (gameObject.activeInHierarchy && target.gameObject.activeInHierarchy)
        {
            target.SetParent(transform, true);
        }
    } 
}
