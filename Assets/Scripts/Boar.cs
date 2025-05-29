using UnityEngine;

public class Boar : Enemy
{

    protected Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
    }

    protected override void EnemyDetected(Collider2D other)
    {
       anim.SetBool("running", true);
    }
    
}
