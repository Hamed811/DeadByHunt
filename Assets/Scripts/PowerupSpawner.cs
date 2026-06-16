using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject speedPowerupPrefab;
    public GameObject teleportPowerupPrefab;

    public float spawnInterval = 20f;

    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnPowerup();

            timer = spawnInterval;
        }
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 spawnPosition =
            new Vector3(randomX, randomY, 0);

        int randomPowerup = Random.Range(0, 2);

        if (randomPowerup == 0)
        {
            Instantiate(
                speedPowerupPrefab,
                spawnPosition,
                Quaternion.identity
            );
        }
        else
        {
            Instantiate(
                teleportPowerupPrefab,
                spawnPosition,
                Quaternion.identity
            );
        }
    }
}