using UnityEngine;

public class Bomb : Collectible
{
    [SerializeField] private int damage = 1;

    void Start()
    {
        collectibleType = "bomb";
        scoreValue = -5; // Minuspunkte für Bomben
    }

    protected override void Collect(GameObject player)
    {
        // Bomben-Logik
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        // Screen Shake Effekt (optional)
        CameraShake shake = Camera.main.GetComponent<CameraShake>();
        if (shake != null)
        {
            shake.ShakeCamera(0.2f, 0.1f);
        }

        // Punktzahl abziehen
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        if (playerScore != null)
        {
            playerScore.AddScore(scoreValue);
        }

        base.Collect(player);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {

        // Überprüfen, ob der Spieler den Bereich berührt
        if (collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Player") && !collected)
            {
                collected = true;
                Collect(collision.gameObject);
            }
            PlayerController.Instance.ResetPlayer();
            //collision.GetComponent<PlayerController>().ResetPlayer();
        }
    }
}