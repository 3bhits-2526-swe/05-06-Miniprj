using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject cloud1Prefab;
    [SerializeField] private GameObject cloud2Prefab;

    [Header("Generation")]
    [SerializeField] private int platformCount = 100;
    [SerializeField] private float minVerticalGap = 1.8f;
    [SerializeField] private float maxVerticalGap = 3.0f;
    [SerializeField] private float minHorizontalGap = 1.5f;

    [Header("Spawn Chances")]
    [SerializeField] private float coinSpawnChance = 0.3f;
    [SerializeField] private float bombSpawnChance = 0.1f;

    [Header("Background Parallax")]
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxFactor = 0.3f;

    private Camera cam;
    private float cameraStartY;
    private float backgroundStartY;
    private float halfScreenWidth;
    private float lastPlatformX;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;
    }

    private void Start()
    {
        cameraStartY = cam.transform.position.y;

        if (background != null)
            backgroundStartY = background.position.y;

        // Calculate visible width in world units
        halfScreenWidth = cam.orthographicSize * cam.aspect;

        GenerateLevel();
    }

    private void Update()
    {
        HandleParallax();
    }

    internal void GenerateLevel()
    {
        DestroyLevel();

        Vector3 spawnPosition = Vector3.zero;
        lastPlatformX = 0f;

        for (int i = 0; i < platformCount; i++)
        {
            // Vertical spacing
            spawnPosition.y += Random.Range(minVerticalGap, maxVerticalGap);

            // Horizontal spacing (avoid overlaps)
            float newX;
            do
            {
                newX = Random.Range(-halfScreenWidth + 0.5f, halfScreenWidth - 0.5f);
            }
            while (Mathf.Abs(newX - lastPlatformX) < minHorizontalGap);

            spawnPosition.x = newX;
            lastPlatformX = newX;

            // Platform
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity, transform);

            // Coins
            if (Random.value < coinSpawnChance && coinPrefab != null)
            {
                Instantiate(
                    coinPrefab,
                    spawnPosition + Vector3.up * 1.5f,
                    Quaternion.identity,
                    transform
                );
            }

            // Bombs
            if (Random.value < bombSpawnChance && bombPrefab != null)
            {
                Instantiate(
                    bombPrefab,
                    spawnPosition + Vector3.up * 1.5f,
                    Quaternion.identity,
                    transform
                );
            }

            // Clouds
            float cloudChance = Random.value;
            if (cloudChance < 0.07f && cloud1Prefab != null)
            {
                Instantiate(
                    cloud1Prefab,
                    spawnPosition + new Vector3(Random.Range(-2f, 2f), Random.Range(3f, 5f), 10f),
                    Quaternion.identity,
                    transform
                );
            }
            else if (cloudChance < 0.14f && cloud2Prefab != null)
            {
                Instantiate(
                    cloud2Prefab,
                    spawnPosition + new Vector3(Random.Range(-2f, 2f), Random.Range(3f, 5f), 10f),
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    private void DestroyLevel()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void HandleParallax()
    {
        if (background == null) return;

        float cameraDeltaY = cam.transform.position.y - cameraStartY;

        background.position = new Vector3(
            background.position.x,
            backgroundStartY + cameraDeltaY * parallaxFactor,
            background.position.z
        );
    }
}
