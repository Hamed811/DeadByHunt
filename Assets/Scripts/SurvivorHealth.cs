using UnityEngine;

using System.Collections;

public class SurvivorHealth : MonoBehaviour
{
    public ParticleSystem bloodParticles;
    private AudioSource audioSource;
    public int health = 2;

    public HealthUI healthUI;

    private bool invincible = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healthUI.UpdateHealth(health);
    }

    public void TakeHit(GameObject killer)
    {
        if (invincible)
            return;

        health--;
        bloodParticles.Play();
        audioSource.Play();

        healthUI.UpdateHealth(health);

        Debug.Log("Survivor HP: " + health);

        if (health <= 0)
        {
            GameManager.Instance.EndGame("KILLER WINS");
            return;
        }

        StartCoroutine(HitEffect(killer));
    }

    IEnumerator HitEffect(GameObject killer)
    {
        invincible = true;

        PlayerMovement survivorMovement = GetComponent<PlayerMovement>();
        PlayerMovement killerMovement = killer.GetComponent<PlayerMovement>();

        survivorMovement.currentSpeed += 2f;
        killerMovement.currentSpeed -= 2f;

        yield return new WaitForSeconds(2f);

        survivorMovement.currentSpeed = survivorMovement.moveSpeed;
        killerMovement.currentSpeed = killerMovement.moveSpeed;

        invincible = false;
    }
}