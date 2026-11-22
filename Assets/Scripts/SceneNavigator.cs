using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void GoToMap()
    {
        // Возвращаемся (индекс 1)
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        // Возвращаемся (индекс 0)
        SceneManager.LoadScene(0);
    }
}