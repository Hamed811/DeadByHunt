using UnityEngine;

public class TeleportPowerup : MonoBehaviour
{
    public AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Survivor"))
            return;

        TeleportAbility ability =
            other.GetComponent<TeleportAbility>();

        if (ability != null)
        {
            ability.hasTeleport = true;

            GameManager.Instance.teleportReadyText.SetActive(true);

            Debug.Log("Teleport Collected!");

            AudioSource.PlayClipAtPoint(
              pickupSound,
              transform.position
              );

            Destroy(gameObject);
        }
    }
}