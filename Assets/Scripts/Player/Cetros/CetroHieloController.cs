using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CetroHieloController : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float shootCooldown = 1f; 
    private float timeSinceLastShot = 1f; 

    public bool canShoot = true;//

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Aim();
        HandleShooting();
    }
    void HandleShooting()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootCooldown && Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            timeSinceLastShot = 0f;
        }
    }
    //void Shoot()
    //{
    //    if (canShoot && Input.GetButtonDown("Fire1"))
    //    {
    //        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    //    }
    //}
    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
}
