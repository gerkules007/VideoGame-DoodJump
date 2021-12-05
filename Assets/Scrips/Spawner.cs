using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX, maxX, YRangeMin, YRangeMax, cameraDistance, frequencyAppear;
    public Transform platformPrefab;
    public Transform platformPrefabDisappear;
    private Transform cam, platform;
    private float lastSpawnY, lastSpawnDisappear, AppearRange, newBlockPoint;
    void Start()
    {
        cam = Camera.main.transform;
        lastSpawnY = -7;
        AppearRange = 101 - frequencyAppear;
    }

    void Update()
    {
        // Как только камера выше последней позиции персонажа
        if (cam.position.y + cameraDistance > lastSpawnY)
        {
            newBlockPoint = Random.Range(0, 101);
            if (newBlockPoint > AppearRange)
            {
                platform = Instantiate(platformPrefabDisappear,
                    new Vector3(Random.Range(minX, maxX), lastSpawnY + Random.Range(YRangeMin, YRangeMax), 0), Quaternion.identity);
            }
            // Для платформы - создаем объект из ничего (Insantiate) из платформы для прыжка в случайном положении на карте
            // где платформа по высоте изменяется каждый раз от места появления персонаж для игры
            else
            {
                platform = Instantiate(platformPrefab,
                    new Vector3(Random.Range(minX, maxX), lastSpawnY + Random.Range(YRangeMin, YRangeMax), 0), Quaternion.identity);
            }
            // Сохраняем позицию персонажа для дальнейшего расчета
            lastSpawnY = platform.position.y;
        }
    }
}
