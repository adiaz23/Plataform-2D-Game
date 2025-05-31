using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] private int lives;

    private int maxLives = 100;

    private void Start()
    {
        if (healthBar != null)
            healthBar.SetMaxHealth(maxLives);
    }

    public void GetDamage(int damage)
    {
        lives -= damage;
        if (healthBar != null)
            healthBar.SetHealth(lives);
    }

    public int GetLives()
    {
        return lives;
    }

    public void StartDeadAnimation(Animator animator)
    {
        animator.SetTrigger("dead");
    }

    public void DestroyGameObject()
    {
        GetComponent<ItemDrop>().DropItems();
        Destroy(gameObject);
    }

    public void RestoreHealth(int healthAmount)
    {
        lives = Mathf.Min(lives + healthAmount, maxLives);
        if (healthBar != null)
            healthBar.SetHealth(lives);
    }

}
