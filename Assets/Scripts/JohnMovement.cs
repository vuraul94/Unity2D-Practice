using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 1;
    public int health = 5;
    public GameObject bulletPrefab;

    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    private float lastShoot;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        if (horizontal < 0.0f)
            transform.localScale = new Vector2(-1.0f, 1.0f);
        else if(horizontal > 0.0f)
            transform.localScale = new Vector2(1.0f, 1.0f);

        animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * 150 * jumpForce);
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

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(horizontal, rigidBody2D.velocity.y);
    }

    public void Hit(){
        health = health - 1;
        if(health <= 0) Destroy(gameObject);
    }
}
