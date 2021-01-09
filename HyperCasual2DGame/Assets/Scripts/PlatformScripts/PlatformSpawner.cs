using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] moving_Platform;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_X = -2f, min_Y = 2f;

   
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

   
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if(current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, min_Y);

            GameObject newPlatform = null;

            if(platform_Spawn_Count < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }else if(platform_Spawn_Count == 2)
            {
                if(Random.Range(0, 10) > 6)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(moving_Platform[Random.Range(0, moving_Platform.Length)], temp, Quaternion.identity);
                }
            }else if(platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 10) > 6)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 10) > 6)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                platform_Spawn_Count = 0;
            }
            if(newPlatform)
            newPlatform.transform.parent = transform;

            current_Platform_Spawn_Timer = 0f;
        } //spawn platform
    }
}
