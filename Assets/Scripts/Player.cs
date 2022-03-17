using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isImmune = false;

    public float speed = 5f;
    public float jumpForce = 5f;
    public float movHor;

    public float immuneTimeCnt = 0f;
    public float immuneTime = 0;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private SpriteRenderer spr;
    private Animator ani;
    private Rigidbody2D rb;


    void Awake()
    {
        obj = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

       
        movHor = Input.GetAxis("Horizontal");
        isMoving = (movHor != 0);
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

            ani.SetBool("isMoving", isMoving);
            ani.SetBool("isGrounded", isGrounded);
        
        flip(movHor);
    }

    private void FixedUpdate()
    {
      
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void OnDestroy()
    {
        obj = null;
        
    }

    public void Jump()
    {
        if (!isGrounded) return;
        rb.velocity = Vector2.up * jumpForce;
    }
    public void flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if(_xValue < 0)
        {
            theScale.x = Mathf.Abs(theScale.x)*-1;
        }else if (_xValue > 0)
        {
            theScale.x = Mathf.Abs(theScale.x);
        }
        transform.localScale = theScale;
    }
   

}
