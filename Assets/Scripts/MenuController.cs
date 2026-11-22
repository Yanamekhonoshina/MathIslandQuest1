using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        // Очищаем все сохранения прогресса
        PlayerPrefs.DeleteKey("BeachCompleted");
        PlayerPrefs.DeleteKey("ForestCompleted");
        PlayerPrefs.DeleteKey("RockCompleted");
        PlayerPrefs.DeleteKey("CurrentLocation"); // Сбрасываем локацию

        // Переходим на сцену с картой
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        // Просто загружаем карту
        SceneManager.LoadScene(1);
    }
}