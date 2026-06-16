using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour
{
    public AudioClip pickupSound;
    public float speedBonus = 2f;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement movement =
            other.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            StartCoroutine(ApplyBoost(movement));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator ApplyBoost(PlayerMovement movement)
    {
        movement.currentSpeed += speedBonus;

        yield return new WaitForSeconds(duration);

        movement.currentSpeed -= speedBonus;

        AudioSource.PlayClipAtPoint(
        pickupSound,
        transform.position
        );
        Destroy(gameObject);
    }
}