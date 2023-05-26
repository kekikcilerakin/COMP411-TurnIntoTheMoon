using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCloudGenerator3 : MonoBehaviour
{
    public List<CloudNotr> PlatformPrefabs;
    public int numberOfPlatforms = 100;
    public float minGap = 4.0f;
    public float maxGap = 6.0f;
    public float minHeight = -2.0f;
    public float maxHeight = 2.0f;

    private Vector3 lastPlatformPosition;

    void Start()
    {
        lastPlatformPosition = transform.position;
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minHeight, maxHeight);

            Vector3 newPlatformPosition = new Vector3(lastPlatformPosition.x + gap, lastPlatformPosition.y + height, 0);

            float randomValue = Random.value;

            if (randomValue <= 0.6f)
            {
                Instantiate(PlatformPrefabs[0], newPlatformPosition, Quaternion.identity);
            }
            else if (randomValue <= 0.7f)
            {
                Instantiate(PlatformPrefabs[1], newPlatformPosition, Quaternion.identity);
            }
            else if (randomValue <= 0.8f)
            {
                Instantiate(PlatformPrefabs[2], newPlatformPosition, Quaternion.identity);
            }
            else if (randomValue <= 1.0f)
            {
                Instantiate(PlatformPrefabs[3], newPlatformPosition, Quaternion.identity);
            }

            lastPlatformPosition = newPlatformPosition;
        }
    }
}
