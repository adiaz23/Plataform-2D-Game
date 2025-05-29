using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float lives;

    public void GetDamage(float damage)
    {
        lives -= damage;
    }

    public float GetLives()
    {
        return lives;
    }

    public void StartDeadAnimation(Animator animator)
    {
        animator.SetTrigger("dead");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
