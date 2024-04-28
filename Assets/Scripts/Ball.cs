using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    public Vector3 startPosition;
    public float speedIncreaseAmount; // ความเร็วที่จะเพิ่มขึ้นเมื่อชน

    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    void Update()
    {

    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector2 target = new Vector2(startPosition.x + Random.Range(-1f, 1f), startPosition.y + Random.Range(-1f, 1f));
        float t = CalculateTimeToTarget(transform.position, target, speed);// ตำนวนเวลา
        Vector2 velocity = CalculateProjectileVelocity(transform.position, target, t);// คำนวนค่า Projectile

        rb.velocity = velocity;
    }

    private float CalculateTimeToTarget(Vector2 origin, Vector2 target, float speed)// ตำนวนเวลา
    {
        float distance = Vector2.Distance(origin, target);
        float time = distance / speed;
        return time;
    }

    private Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t) // คำนวนค่า Projectile
    {
        Vector2 distance = target - origin;
        Vector2 velocity = distance / t;
        return velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าลูกชนกับวัตถุอื่น ๆ
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            // เพิ่มความเร็ว
            rb.velocity = rb.velocity.normalized * (speed + speedIncreaseAmount);
        }
    }
}
