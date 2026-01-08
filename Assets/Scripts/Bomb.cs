using UnityEngine;

public class Bomb : Collectible
{

    void Start()
    {
        collectibleType = "bomb";
        scoreValue = -5; // Minuspunkte für Bomben
    }

    protected override void Collect(GameObject player)
    {
        // Screen Shake Effekt (optional)
        CameraShake shake = Camera.main.GetComponent<CameraShake>();
        if (shake != null)
        {
            shake.ShakeCamera(0.2f, 0.1f);
        }

        // Punktzahl abziehen
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.AddScore(scoreValue);
        }

        base.Collect(player);
        
        // Reset player and score
        PlayerController.Instance.ResetPlayer();
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.ResetScore();
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfen, ob der Spieler den Bereich berührt
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;
            Collect(collision.gameObject);
        }
    }
}