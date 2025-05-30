using UnityEngine;

public class Boar : Enemy
{

    protected override void EnemyDetected(Collider2D other)
    {
        animator.SetBool("running", true);
    }
}
