using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float currentSpeed;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    void Start()
    {
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(upKey))
            movement.y += 1;

        if (Input.GetKey(downKey))
            movement.y -= 1;

        if (Input.GetKey(leftKey))
            movement.x -= 1;

        if (Input.GetKey(rightKey))
            movement.x += 1;

        movement.Normalize();

        transform.position += (Vector3)movement * currentSpeed * Time.deltaTime;
    }
}