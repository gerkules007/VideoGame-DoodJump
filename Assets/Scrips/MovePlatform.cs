using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float Speed, MinX, MaxX;
    private bool right;
    void Update()
    {
        // проверяем положение платформы, если двигается вправо и влево и переходит границы максимальной длины
        if (right && transform.position.x < MaxX) 
        // К позиции мы прибавляем вектор, которые смотрит вправо и усиливаем его скоростью и временем, которое не зависит от скорости отрисовки кадров
        transform.position += Vector3.right * Speed * Time.deltaTime;
        else if (right) right = false;
        else if (!right && transform.position.x > MinX) transform.position += Vector3.left * Speed * Time.deltaTime;
        else if (!right) right = true;
    }
}
