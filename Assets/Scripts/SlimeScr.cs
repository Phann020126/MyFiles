using UnityEngine;

public class SlimeScr : MonoBehaviour
{
    
    [SerializeField] private float speed = 1;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingright = true;
    private float dist = 4f;

    public LayerMask ground;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SlimeMovement();
    }

    private void  SlimeMovement()
    {
        if (facingright)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
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
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            facingright = !facingright;
        }
    }

}
