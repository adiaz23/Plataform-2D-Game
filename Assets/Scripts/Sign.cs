using Unity.VisualScripting;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
            gameManager.ShowText();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            gameManager.HideText();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
           
    }
}
