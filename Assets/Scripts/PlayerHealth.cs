/*
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Spieler stirbt - zurück zum Spawnpunkt
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ResetPlayer();
        }
        
        // Health zurücksetzen
        currentHealth = maxHealth;

        // Score zurücksetzen
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.ResetScore();
        }
    }
}
*/