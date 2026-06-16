using UnityEngine;

public class CharacterDirection : MonoBehaviour
{
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateDirection(Vector2 movement)
    {
        if (movement.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.sprite = rightSprite;
            spriteRenderer.flipX = true;
        }
        else if (movement.y > 0)
        {
            spriteRenderer.sprite = upSprite;
            spriteRenderer.flipX = false;
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = downSprite;
            spriteRenderer.flipX = false;
        }
    }
}