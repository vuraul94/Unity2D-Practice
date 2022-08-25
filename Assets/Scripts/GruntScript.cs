using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public int health = 3;

    public GameObject John;

    public GameObject bulletPrefab;

    private float lastShoot;

    // Update is called once per frame
    void Update()
    {
        if (John == null)
        {
            return;
        }
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance =
            Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > lastShoot + 0.5f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x > 0)
            direction = Vector3.right;
        else
            direction = Vector3.left;
        GameObject bullet =
            Instantiate(bulletPrefab,
            transform.position + direction * 0.1f,
            Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        health = health - 1;
        if (health <= 0) Destroy(gameObject);
    }
}
