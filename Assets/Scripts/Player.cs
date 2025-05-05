using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float speed = 12;
    [SerializeField] private float jumbForce = 30;
    private Rigidbody2D rb;
    private float inputH;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Jumb();
    }

    private void Move()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH  * speed, rb.linearVelocityY);
    }

    private void Jumb(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
        }
    
    }
}
