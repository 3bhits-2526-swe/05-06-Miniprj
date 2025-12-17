using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;
    public string collectibleType = "coin";
    public AudioClip collectSound;
    
    // Verhindert mehrfaches Sammeln
    protected bool collected = false;
    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;
            Collect(collision.gameObject);
        }
    }
    
    protected virtual void Collect(GameObject player)
    {
        // Soundeffekt abspielen
        if (collectSound != null)
        {
            
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        
        // Collectible zerstören
        
        Destroy(gameObject);
    }
}