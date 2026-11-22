using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public Button beachButton;
    public Button forestButton;
    public Button rockButton;

    void Start()
    {
        // Проверяем, что уже пройдено
        if (PlayerPrefs.GetInt("BeachCompleted", 0) == 1)
        {
            beachButton.image.color = Color.gray; // Красим в серый
        }

        if (PlayerPrefs.GetInt("ForestCompleted", 0) == 1)
        {
            forestButton.image.color = Color.gray;
        }

        if (PlayerPrefs.GetInt("RockCompleted", 0) == 1)
        {
            rockButton.image.color = Color.gray;
        }
    }

    public void OpenLocation(string locationName)
    {
        PlayerPrefs.SetString("CurrentLocation", locationName);
        SceneManager.LoadScene(2);
    }
}