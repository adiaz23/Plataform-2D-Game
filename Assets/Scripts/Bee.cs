using UnityEngine;

public class Bee : Enemy
{

    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
    }

    protected override void LaunchAttack()
    {
        anim.SetTrigger("Attack");
    }
}
