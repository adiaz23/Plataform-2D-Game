using System.Collections;
using UnityEngine;

public class Wizard : Enemy
{

    [SerializeField] private GameObject fireBall;
    [SerializeField] private float attackTime;

    private Transform spawnFireBallsPoint;
    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        spawnFireBallsPoint = transform.GetChild(1);
    }

    protected override void EnemyDetected(Collider2D other)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (gameObject)
        {
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(attackTime);
        }
    }

    //Animation event
    private void shootFireBall()
    {
        Instantiate(fireBall, spawnFireBallsPoint.position, transform.rotation);
    }
}
