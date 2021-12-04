using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodPlayer : MonoBehaviour
{
    public float MoveSpeed, JumpForce, MoveDecreaser;

    private Rigidbody2D rb;  
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.y <= 0) 
        {
            Vector2 jumpVelo = rb.velocity;
            jumpVelo.y = JumpForce;
            rb.velocity = jumpVelo;
        }
    }

    void Update()
    {
        Vector2 newVelo = rb.velocity;

        if(Input.GetMouseButton(0)) newVelo.x = Input.mousePosition.x < Screen.width/2 ? -MoveSpeed : MoveSpeed;
        else newVelo.x *= MoveDecreaser;
        rb.velocity = newVelo;
    }
}
