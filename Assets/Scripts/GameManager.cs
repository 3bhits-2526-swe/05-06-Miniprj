using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject cloud1Prefab;
    [SerializeField] private GameObject cloud2Prefab;
    [SerializeField] private int platformCount = 100;
    [SerializeField] private float coinSpawnChance = 0.3f; // 30% Chance für Coins
    [SerializeField] private float bombSpawnChance = 0.1f; // 10% Chance für Bomben

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateLevel();
    }

    internal void GenerateLevel()
    {
        destroyLevel();
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-5f, 5f);

            // Nur EINE Plattform spawnen (die zweite Zeile entfernen!)

            GameObject newPlat = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            newPlat.transform.SetParent(gameObject.transform);

            // Wolken spawnen (zufällig zwischen cloud1 und cloud2)
            float cloudChance = Random.value;
            if (cloudChance < 0.07f && cloud1Prefab != null) // 5% cloud1
            {
                Vector3 cloudPosition = new Vector3(
                    Random.Range(-8f, 8f),
                    spawnPosition.y + Random.Range(2f, 4f),
                    Random.Range(8f, 16f));
                GameObject newCloud = Instantiate(cloud1Prefab, cloudPosition, Quaternion.identity);
                newCloud.transform.SetParent(gameObject.transform);
            }
            else if (cloudChance >= 0.07f && cloudChance < 0.14f && cloud2Prefab != null)
            {
                Vector3 cloudPosition = new Vector3(
                    Random.Range(-8f, 8f),
                    spawnPosition.y + Random.Range(2f, 4f),
                    Random.Range(8f, 16f));
                GameObject newCloud = Instantiate(cloud2Prefab, cloudPosition, Quaternion.identity);
                newCloud.transform.SetParent(gameObject.transform);
            }

            // Coins spawnen
            if (Random.value < coinSpawnChance && coinPrefab != null)
            {
                Vector3 coinPosition = spawnPosition + Vector3.up * 1.5f;
                GameObject newCoin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                newCoin.transform.SetParent(gameObject.transform);
            }

            // Bomben spawnen
            if (Random.value < bombSpawnChance && bombPrefab != null)
            {
                Vector3 bombPosition = spawnPosition + Vector3.up * 1.5f;
                GameObject newBomb = Instantiate(bombPrefab, bombPosition, Quaternion.identity);
                newBomb.transform.SetParent(gameObject.transform);
            }
        }
    }
    private void destroyLevel() 
    {
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
    }

}