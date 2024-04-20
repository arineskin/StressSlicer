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
            // ���������� ��������� ����� ��� �����������, ����� ������ ��������
            int obstacleSpawnChance = Random.Range(1, 6); // ����������� �������� ��� �������� �������� ��� �������

            // ������� BoosterObstacle ����, ��������, � 20% ������
            if (obstacleSpawnChance == 3) // 1 �� 5, ��� ����� �������� 20% �����
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
            // ������� MetalObstacle ����, ��������, � 40% ������
            else if (obstacleSpawnChance >= 3 && obstacleSpawnChance <= 4) // 2 �� 5, ��� ����� �������� 40% �����
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
