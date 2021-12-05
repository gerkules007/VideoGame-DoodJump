using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX, maxX, YRangeMin, YRangeMax, cameraDistance, frequencyDisappearBlock, increaseLevel, UpLevel;
    public Transform platformPrefab1, platformPrefab2, platformPrefabDisappear;
    private Transform cam, platform, choosePlatform;
    private float lastSpawnY, AppearRange, newBlockPoint, countLevel;
    private GameObject Dood;
    void Start()
    {
        cam = Camera.main.transform;
        lastSpawnY = -7;
        AppearRange = 101 - frequencyDisappearBlock;
        countLevel = 0;
    }

    void Update()
    {
        // Как только камера выше последней позиции персонажа
        if (cam.position.y + cameraDistance > lastSpawnY)
        {
            // Создание числа для определения какой блок выберется для создания
            newBlockPoint = Random.Range(0, 101);
            if (newBlockPoint >= AppearRange) choosePlatform = platformPrefabDisappear;
            else
            {
                if (newBlockPoint <= 50) choosePlatform = platformPrefab1;
                else choosePlatform = platformPrefab2;
            }
            // Для платформы - создаем объект из ничего (Insantiate) из платформы для прыжка в случайном положении на карте
            // где платформа по высоте изменяется каждый раз от места появления персонаж для игры
            platform = Instantiate(choosePlatform,
                    new Vector3(Random.Range(minX, maxX), lastSpawnY + Random.Range(YRangeMin, YRangeMax), 0), Quaternion.identity);
            // Сохраняем позицию персонажа для дальнейшего расчета
            lastSpawnY = platform.position.y;
            // Определяем повышения уровня - если количество блоков привысело кратность увеличения уровня, то уровень повышает высоту между блоками
            countLevel++;
            if (countLevel % UpLevel == 0)
            {
                YRangeMin += increaseLevel;
                YRangeMax += increaseLevel;
            }
        }
    }
}
