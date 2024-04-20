using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Vegetables;
    public GameObject MetalObstacle;
    public GameObject BoosterObstacle;
    public Transform SpawnPoint;
    public float IntervalBetweenSpawn;
    private int vegetableSpawnCounterForObstacle;
    private float spawnBetweenTime;

    void FixedUpdate()
    {
        if (spawnBetweenTime <= 0)
        {
            int vegetableRandomIdx = Random.Range(0, Vegetables.Length);
            // Генерируем случайное число для определения, какой объект спавнить
            int obstacleSpawnChance = Random.Range(1, 6); // Увеличиваем диапазон для большего контроля над шансами

            // Спавним BoosterObstacle реже, например, с 20% шансом
            if (obstacleSpawnChance == 3) // 1 из 5, что равно примерно 20% шансу
            {
                if (vegetableSpawnCounterForObstacle > 5)
                {
                    Instantiate(BoosterObstacle, SpawnPoint.position, Quaternion.identity);
                    vegetableSpawnCounterForObstacle = 0;
                }
                else
                {
                    SpawnVegetable(vegetableRandomIdx);
                }
            }
            // Спавним MetalObstacle чаще, например, с 40% шансом
            else if (obstacleSpawnChance >= 3 && obstacleSpawnChance <= 4) // 2 из 5, что равно примерно 40% шансу
            {
                if (vegetableSpawnCounterForObstacle > 3)
                {
                    Instantiate(MetalObstacle, SpawnPoint.position, Quaternion.identity);
                    vegetableSpawnCounterForObstacle = 0;
                }
                else
                {
                    SpawnVegetable(vegetableRandomIdx);
                }
            }
            else
            {
                SpawnVegetable(vegetableRandomIdx);
            }
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else
        {
            spawnBetweenTime -= Time.deltaTime;
        }
    }

    private void SpawnVegetable(int index)
    {
        Instantiate(Vegetables[index], SpawnPoint.position, Quaternion.identity);
        vegetableSpawnCounterForObstacle++;
    }
}
