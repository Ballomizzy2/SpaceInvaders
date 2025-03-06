using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float speedIncreaseFactor = 1.1f;
    public int pointValue = 10;
    public GameObject bulletPrefab;
    public float fireRate = 3f;

    private float currentSpeed;
    private float step = 1;

    private float direction = 1f;
    private float fireTimer;
   private GameManager manager;

    void Start()
    {
        currentSpeed = baseSpeed;
        UpdateSpeed();
        manager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        // Move enemies side to side
        StartCoroutine(MoveStep());

        // Random shooting
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate + Random.Range(5, 10);
        }
    }

    IEnumerator MoveStep()
    {
        yield return new WaitForSeconds(0.2f);
        //transform.Translate(Vector3.right * currentSpeed * direction * Time.deltaTime);
        Vector2 newPos = transform.position;
        if (newPos.x <= -10 || newPos.x >= 10)
        {
            newPos.y -= step/5;
            direction *= -1f;
        }
        //else
            newPos.x += step * speedIncreaseFactor * direction;

        transform.position = newPos;
        yield return new WaitForSeconds(0.2f);

    }

    void UpdateSpeed()
    {
        // Count remaining enemies and increase speed
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentSpeed = baseSpeed + (0.1f * (50 - enemies.Length));
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            manager.AddScore(pointValue);
            Destroy(collision.gameObject);
            UpdateSpeed();
            Destroy(gameObject);
        }
    }
}