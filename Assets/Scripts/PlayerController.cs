using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance{ get; private set; }
    public float moveSpeed = 10.0f;
    private Rigidbody2D rb;

    private float moveX;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveX;
        rb.linearVelocity = velocity;
    }

    public void ResetPlayer()
    {
        GameManager.Instance.GenerateLevel();

        // Finde den Spieler und setze ihn zurück
        if (gameObject != null)
        {
            // Zur Startposition zurücksetzen
            gameObject.transform.position = Vector3.zero;

            // Falls du eine Spieler-Controller-Komponente hast
            PlayerController playerController = gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                transform.position = Vector3.zero;

                // Geschwindigkeit zurücksetzen
                rb.linearVelocity = Vector2.zero;

            }

            // Kamera zurücksetzen, falls vorhanden
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                CameraFollow camFollow = mainCam.GetComponent<CameraFollow>();
                if (camFollow != null)
                {
                    camFollow.ResetCamera();
                }
            }
        }
    }
}
