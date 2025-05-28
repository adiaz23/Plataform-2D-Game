using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float lives;

    public void GetDamage(float damage)
    {
        lives -= damage;
        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
