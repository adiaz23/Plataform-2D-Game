using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] private float shootImpulse;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootImpulse, ForceMode2D.Impulse);
    }
}
