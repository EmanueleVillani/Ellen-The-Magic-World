using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public LayerMask groundLayer;
    public float movHor;
    public float speed = 0.5f;

    public bool isGroundFloor = true;
    public bool idGroundFront = false;

    public float frontGroundRayDist = 0.25f;

    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    private RaycastHit2D hit;

    public int scoreGive = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY - transform.position.z),
            new Vector3(movHor, 0, 0), frontGroundRayDist, groundLayer));

        if (!isGroundFloor)
            movHor = movHor *-1;

        if(Physics2D.Raycast(transform.position,new Vector3(movHor,0,0),frontCheck,groundLayer))
            movHor = movHor * -1;

        hit = Physics2D.Raycast(new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), groundLayer);

        if(hit != null)
            if (hit.transform != null)
                if (hit.transform.CompareTag("Enemy"))
                    movHor = movHor * -1;
    }
     void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void GetKilled()
    {
        gameObject.SetActive(false);

        Destroy(gameObject);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        GetKilled();
        AudioManager.obj.PlayEnemy();
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //AudioManager.obj.PlayHeroHit();
           
            Player.obj.GetDamage();
            Debug.Log("MOcc a Mamt");
        }
    }
}
