using UnityEngine;

public class KillerHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Survivor"))
        {
            SurvivorHealth health =
                collision.gameObject.GetComponent<SurvivorHealth>();

            if (health != null)
            {
                health.TakeHit(gameObject);
            }
        }
    }
}