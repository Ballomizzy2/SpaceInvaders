using UnityEngine;

public class Barricade : MonoBehaviour
{
    public float health = 30f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet") || collision.gameObject.CompareTag("Enemy Bullet"))
        {
            health--;
            transform.localScale *= 0.999f; // Shrink when hit

            if (health <= 0)
                Destroy(gameObject);

            Destroy(collision.gameObject);
        }
    }
}