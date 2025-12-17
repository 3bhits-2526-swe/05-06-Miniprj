using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (target != null && target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }

    // Setzt die Kamera auf die Anfangsposition zurück
    public void ResetCamera()
    {
        transform.position = startPosition;
    }
}
