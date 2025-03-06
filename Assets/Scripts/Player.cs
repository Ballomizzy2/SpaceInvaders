using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float fireTimer;

    private float health = 5;

    void Update()
    {
        // Player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);

        // Shooting
        fireTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet"))
        {
            health--;
            Destroy(collision.gameObject);
            if(health < 0)
            {
                Debug.Log("You Lose");
                PlayerPrefs.SetInt("HiScore", GameManager.Instance.highScore);
                SceneManager.LoadScene("Menu");
            }
        }
    }
}