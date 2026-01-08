using UnityEngine;
public class Coin : Collectible
{
    void Start()
    {
        collectibleType = "coin";
        scoreValue = 1;
    }
    
    protected override void Collect(GameObject player)
    {
        // Münzen-Sammel-Logik
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.AddScore(scoreValue);
        }
        
        base.Collect(player);
    }
}