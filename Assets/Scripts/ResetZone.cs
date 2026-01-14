using UnityEngine;

public class ResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfen, ob der Spieler den Bereich berührt
        if (collision.GetComponent<PlayerController>() != null)
        {
            // Spieler zurücksetzen
            PlayerController.Instance.ResetPlayer();
            if (PlayerScore.Instance != null)
            {
            PlayerScore.Instance.ResetScore();
            }
        }
        if (collision.GetComponent<Platform>() != null)
        {
            
            // Spieler zurücksetzen
            Destroy(collision.gameObject);
        }
    }
}