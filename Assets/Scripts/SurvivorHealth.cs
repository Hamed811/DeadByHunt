using UnityEngine;
using System.Collections;

public class SurvivorHealth : MonoBehaviour
{
    public int health = 2;

    private bool invincible = false;

    public void TakeHit(GameObject killer)
    {
        if (invincible)
            return;

        health--;

        Debug.Log("Survivor HP: " + health);

        if (health <= 0)
        {
            GameManager.Instance.EndGame("KILLER WINS"); return;
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