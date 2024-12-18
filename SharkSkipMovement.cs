using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSkipMovement : MonoBehaviour
{
    Gun[] guns;

    float moveSpeed = 3;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;

    private bool isFacingRight = true;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        shoot = Input.GetKeyDown(KeyCode.Return);
        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }
        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x += moveAmount;
        }
        pos += move;

        if (pos.x <= -9.5f)
        {
            pos.x = -9.5f;
        }
        if (pos.x >= 9.5f)
        {
            pos.x = 9.5f;
        }
        if (pos.y >= 4.1f)
        {
            pos.y = 4.1f;
        }
        if (pos.y <= -3.8f)
        {
            pos.y = -3.8f;
        }
        if (move.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move.x < 0 && isFacingRight)
        {
            Flip();
        }

        transform.position = pos;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }
}
