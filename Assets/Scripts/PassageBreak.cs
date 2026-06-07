using UnityEngine;
using System.Collections;

public class PassageBreak : MonoBehaviour
{
    public SpriteRenderer passageSprite;

    private bool isBreaking = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreaking)
            return;

        if (collision.gameObject.CompareTag("Killer"))
        {
            StartCoroutine(BreakPassage());
        }
    }

    IEnumerator BreakPassage()
    {
        isBreaking = true;

        passageSprite.color = Color.red;

        yield return new WaitForSeconds(1f);

        passageSprite.gameObject.SetActive(false);

        GetComponent<Collider2D>().enabled = false;
    }
}