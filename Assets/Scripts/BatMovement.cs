using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Vector3 targetPosition;

    private const float MIN_X = -8.4f;
    private const float MAX_X = 8.5f;

    private const float MIN_Y = -4.4f;
    private const float MAX_Y = 4.5f;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            PickNewTarget();
        }

        if (targetPosition.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void PickNewTarget()
    {
        targetPosition = new Vector3(
            Random.Range(MIN_X, MAX_X),
            Random.Range(MIN_Y, MAX_Y),
            0
        );
    }
}