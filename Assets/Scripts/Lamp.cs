using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Transform lampLight;
    void Start()
    {
        lampLight = transform.GetChild(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerHitBox"))
            lampLight.gameObject.SetActive(true);
    }
}
