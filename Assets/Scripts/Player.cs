using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;
    
    public float flashTime ;
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
        if (Game.obj.gamePaused)
        {
            movHor = 0f;
            return;
        }

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
        AudioManager.obj.PlayJump();
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
   public void GetDamage()
    {
        
        lives--;
        FlashStart();
        
        AudioManager.obj.PlayHeroHit();
        UiManager.obj.UpdateLives();
       
        if (lives < 0)
           
        {
            this.gameObject.SetActive(false);
           // Destroy(gameObject);
        }
    }
    public void AddLive()
    {
        lives++;
        if (lives > Game.obj.maxLives)
            lives = Game.obj.maxLives;
        UiManager.obj.UpdateLives();
    }

    public void FlashStart()
    {
        spr.enabled = false;

        Invoke("FlashStop", flashTime);

    }
    public void FlashStop()
    {

        spr.enabled = true;
    }

}

