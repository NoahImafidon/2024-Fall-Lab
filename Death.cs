using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        LevelManager.instance.AddScore(10);  

        if (bullet != null)
        {
            
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            
            LevelManager.instance.AddScore(10); 
            LevelManager.instance.GoToNextLevel();
            
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
