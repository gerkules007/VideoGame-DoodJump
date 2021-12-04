using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX, maxX, YRangeMin, YRangeMax, cameraDistance;
    public Transform platformPrefab;
    private Transform cam;
    private float lastSpawnY;
    void Start()
    {
        cam = Camera.main.transform;
        lastSpawnY = -7;
    }

    void Update()
    {
        // Как только камера выше последней позиции персонажа
        if (cam.position.y + cameraDistance > lastSpawnY)
        {
            // Для платформы - создаем объект из ничего (Insantiate) из платформы для прыжка в случайном положении на карте
            // где платформа по высоте изменяется каждый раз от места появления персонаж для игры
            Transform platform = Instantiate(platformPrefab, 
                new Vector3( Random.Range(minX, maxX), lastSpawnY + Random.Range(YRangeMin,YRangeMax), 0 ), Quaternion.identity);
            // Сохраняем позицию персонажа для дальнейшего расчета
            lastSpawnY = platform.position.y;
        }
    }
}
