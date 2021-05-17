using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    idle,
    run,
    jump,
    fall,
    hit,
    attack,
    interact
}


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    [SerializeField] private LayerMask ground ;
    public Animator anim;


    public State state;
    public float speed = 5f ;
    public float jumpspeed = 5f ;
    public float hurtforce = 10f;
    private float movx;
    private bool invulnerability = false;

    void Start()
    {
        state = State.idle;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        Movement();

        Switchstate();

        anim.SetInteger("state", (int)state);
    }

    private void Attack()
    {
        if(Input.GetButtonDown("Attack") && state != State.hit )
        {
            state = State.attack;

        }
    }

    private void Movement()
    {
        movx = Input.GetAxisRaw("Horizontal");
        if (movx != 0 && state != State.hit)
        {
            transform.localScale = new Vector3(movx * 0.4f, 0.4f, 1);
            rb.velocity = new Vector2(movx * speed, rb.velocity.y);
        }
        else if( state != State.hit )
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground) && state != State.hit)
        {
            Jump();
        }
    }

    private void Jump()
    {
        state = State.jump;
        rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
    }

    private void Switchstate()
    {
        if( state == State.hit )
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if( state == State.jump )
        {
            if(rb.velocity.y < -.1f)
            {
                state = State.fall;
            }
        }
        else if(rb.velocity.y < -.5f)
        {
            state = State.fall;
        }
        else if( state == State.fall )
        {
            if( coll.IsTouchingLayers(ground) )
            {
                state = State.idle;
            }
        }
        else if( Mathf.Abs(rb.velocity.x) > 1.5f )
        {
            state = State.run ;
        }
        else
        {
            state = State.idle ;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Slime" )
        {
            if(state == State.fall)
            {
                Destroy(collision.gameObject);
                //invulnerability = true;
                //Invoke("SetInvulnerabilityToFalse", 0.5f);

                Jump();
            }
            else 
            {
                state = State.hit;
                if(collision.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtforce, rb.velocity.y);
                }
                Invoke("ReloadScene", 1f);
            }
        }

        if( collision.gameObject.tag == "Enemy" )
        {
            state = State.hit;
            if(collision.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(hurtforce, rb.velocity.y);
            }
            Invoke("ReloadScene", 1f);
        }

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Bioma01");
    }

    /*private void SetInvulnerabilityToFalse()
    {
        invulnerability = false;
    }*/

}
