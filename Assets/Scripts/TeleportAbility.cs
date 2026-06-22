using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    public bool hasTeleport = false;

    public float teleportDistance = 4f;

    private Vector2 lastDirection = Vector2.right;

    private const float MIN_X = -8.4f;
    private const float MAX_X = 8.5f;

    private const float MIN_Y = -4.4f;
    private const float MAX_Y = 4.5f;

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            movement.y += 1;

        if (Input.GetKey(KeyCode.S))
            movement.y -= 1;

        if (Input.GetKey(KeyCode.A))
            movement.x -= 1;

        if (Input.GetKey(KeyCode.D))
            movement.x += 1;

        if (movement != Vector2.zero)
        {
            lastDirection = movement.normalized;
        }

        if (hasTeleport && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Current Position: " + transform.position);

            Vector3 newPosition =
                transform.position +
                (Vector3)(lastDirection * teleportDistance);

            Debug.Log("Before Clamp: " + newPosition);

            newPosition.x = Mathf.Clamp(newPosition.x, MIN_X, MAX_X);
            newPosition.y = Mathf.Clamp(newPosition.y, MIN_Y, MAX_Y);

            Debug.Log("After Clamp: " + newPosition);

            transform.position = newPosition;

            hasTeleport = false;
            GameManager.Instance.teleportReadyText.SetActive(false);

            Debug.Log("Teleported!");
        }
    }
}