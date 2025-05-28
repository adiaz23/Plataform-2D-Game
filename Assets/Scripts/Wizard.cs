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
        StartCoroutine(Attack());
        spawnFireBallsPoint = transform.GetChild(1);
    }

    void Update()
    {

    }

    IEnumerator Attack()
    {
        while (gameObject)
        {
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(attackTime);
        }
    }

    private void shootFireBall()
    {
        Instantiate(fireBall, spawnFireBallsPoint.position, transform.rotation);
    }
}
