using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f; 
    public Vector2 direction = Vector2.right;

    void Update()
    {
        
        transform.Translate(direction * bulletSpeed * Time.deltaTime);

    
        if (transform.position.y > 10f || transform.position.y < -10f ||
            transform.position.x > 15f || transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
