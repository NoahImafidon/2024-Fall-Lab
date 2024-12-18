using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSideScroll : MonoBehaviour
{
    public float speed = 0.001f;
    private Vector3 StartPosition;

    private SharkSkipMovement playerMovement;
    private bool isMovingRight = true;

    void Start()
    {
        StartPosition = transform.position;

        playerMovement = FindObjectOfType<SharkSkipMovement>();
    }

    void Update()
    {
        if (playerMovement != null)
        {
            isMovingRight = playerMovement.IsFacingRight();
        }

        Vector3 scrollDirection = isMovingRight ? Vector3.left : Vector3.right;
        transform.Translate(scrollDirection * speed * Time.deltaTime);

        if (transform.position.x < -22.5f || transform.position.x > 22.5f)
        {
            transform.position = StartPosition;
        }
    }
}
