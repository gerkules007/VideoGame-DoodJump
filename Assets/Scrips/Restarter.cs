using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
  public void RestartGame()
  {
    // Получаем предварительно номер сцены в которой сейчас находимся и загружаем ее
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
