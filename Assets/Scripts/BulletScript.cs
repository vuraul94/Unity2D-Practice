using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;

    public float speed = 1.0f;

    public Boolean friendBullet = true;

    private Rigidbody2D rigibbody2D;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigibbody2D = GetComponent<Rigidbody2D>();
        if (Sound != null)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        }
    }

    void FixedUpdate()
    {
        rigibbody2D.velocity = direction * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    public void DestroyBullet()
    {
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement john = collision.GetComponent<JohnMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        if (john != null && !friendBullet)
        {
            john.Hit();
            DestroyBullet();
        }
        if (grunt != null && friendBullet)
        {
            grunt.Hit();
            DestroyBullet();
        }
    }
}
