using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterDirection direction;
    public float moveSpeed = 5f;
    public float currentSpeed;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        direction = GetComponent<CharacterDirection>();
        currentSpeed = moveSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (direction != null)
        {
            direction.UpdateDirection(movement);
        }
        movement.Normalize();

        transform.position += (Vector3)movement * currentSpeed * Time.deltaTime;
    }
}