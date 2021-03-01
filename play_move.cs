using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_move : MonoBehaviour
{
    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }
    void playerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        //Animations
        //Player Dir
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}