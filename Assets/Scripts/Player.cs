using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float speed = 12;
    [SerializeField] private float jumbForce = 30;
    private Rigidbody2D rb;
    private Animator animator;
    private float inputH;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Jump();
       Attack();
    }

    private void Move()
    {   animator.SetBool("running", false);
        inputH = Input.GetAxisRaw("Horizontal");
        if (inputH != 0){
            animator.SetBool("running", true);
            if(inputH > 0){
                transform.eulerAngles = Vector3.zero;
            } else {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
            
        rb.linearVelocity = new Vector2(inputH  * speed, rb.linearVelocityY);
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }

    private void Attack(){
        if(Input.GetKeyDown(KeyCode.E)){
            animator.SetTrigger("attack");
        }
    }
}
