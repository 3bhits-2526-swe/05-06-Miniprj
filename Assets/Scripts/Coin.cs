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
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        if (playerScore != null)
        {
            playerScore.AddCoin();
            playerScore.AddScore(scoreValue);
        }
        
        base.Collect(player);
    }
}