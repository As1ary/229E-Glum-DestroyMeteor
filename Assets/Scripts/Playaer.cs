using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playaer : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] Rigidbody2D bulletPrefabs;
    [SerializeField] GameObject target;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if(hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                Vector2 projectile = CalculateProjectileVelocity (shootPoint.position, hit.point, 1f);
                Rigidbody2D firedBullet = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                firedBullet.velocity = projectile;
            }
        }
    }
    Vector2 CalculateProjectileVelocity (Vector2 origin , Vector2 target , float t)
    {
        Vector2 distance = target - origin;

        float distX = distance.x;
        float distY = distance.y;

        float velocityX = distX / t;
        float velocityY = distY / t;

        Vector2 result = new Vector2(velocityX , velocityY);
        return result;
    }
}
