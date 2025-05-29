using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] private int lives;


    private void Start()
    {   
        if(healthBar != null)
            healthBar.SetMaxHealth(lives);
    }

    public void GetDamage(int damage)
    {
        if (healthBar != null)
        {
            lives -= damage;
            healthBar.SetHealth(lives);
        }
        
    }

    public int GetLives()
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
