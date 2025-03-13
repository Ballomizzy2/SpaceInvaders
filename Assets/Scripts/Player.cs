using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    private float fireTimer;

    private float health = 5;

    private Animator anim;

    GameManager menuManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        menuManager = FindAnyObjectByType<GameManager>();
    }

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
        anim.SetTrigger("Shoot");
        menuManager.audio.PlayOneShot(menuManager.playerShoot);
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
                anim.SetTrigger("Explode");
                menuManager.audio.PlayOneShot(menuManager.playerExplode);
                PlayerPrefs.SetInt("HiScore", GameManager.Instance.highScore);
                StartCoroutine(loadMenu());

                IEnumerator loadMenu() { yield return new WaitForSeconds(1.5f); SceneManager.LoadScene("Credits"); }
            }
        }
    }
}