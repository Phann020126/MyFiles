using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ibscr : MonoBehaviour
{
    private Transform target;
    private Animator anim;
    public float chaseRadius = 7;
    public float attackRadius = 6;


    private float speed = 1;
    private float attackSpeed = 5;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingright = true;
    private float dist = 2f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            anim.SetTrigger("Attack");
            CheckDistance();
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            
            CheckDistance();
        }
        else
        {
            
            EnemyMovement();
        }
        
    }

    private void EnemyMovement()
    {
        if (facingright)
        {
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
            Vector3 groundcheck = new Vector3(transform.position.x + (2 * transform.localScale.x), transform.position.y, transform.position.z);
            RaycastHit2D _hit = Physics2D.Raycast(groundcheck, Vector3.down, dist);
            if (_hit.collider == true)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                facingright = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
            Vector3 groundcheck = new Vector3(transform.position.x + (2 * transform.localScale.x), transform.position.y, transform.position.z);
            RaycastHit2D _hit = Physics2D.Raycast(groundcheck, Vector3.down, dist);
            if (_hit.collider == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                facingright = true;
            }
        }
    }

    private void CheckDistance()
    {
            if(target.position.x-transform.position.x > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                rb.velocity = new Vector2(attackSpeed, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                rb.velocity = new Vector2(-attackSpeed, rb.velocity.y);
            }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player"))
        {
            facingright = !facingright;
        }
    }
}
