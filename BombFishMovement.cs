using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFishMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool isFacingRight = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x += (isFacingRight ? 1 : -1) * moveSpeed * Time.fixedDeltaTime;

        if (pos.x < -10 && !isFacingRight || pos.x > 10 && isFacingRight)
        {
            Flip();
        }

        transform.position = pos;
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
