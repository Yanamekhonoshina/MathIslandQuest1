using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [Header("Фоны")]
    public Image backgroundImage;
    public Sprite beachSprite;
    public Sprite forestSprite;
    public Sprite rockSprite;

    [Header("Интерфейс задачи")]
    public TextMeshProUGUI taskText;
    public TMP_InputField answerInput;

    [Header("Подсказки")]
    public GameObject hintButtonObject; 
    public GameObject hintTextObject; 

    [Header("Элементы для скрытия/показа")]
    public GameObject answerInputObject;
    public GameObject submitButtonObject;
    public GameObject finishButtonObject;
    public GameObject backButtonObject;

    private string currentLocation;
    private int currentTaskIndex = 0;

    // Задачки
    private string[] beachTasks = {
        "Мы нашли бревно. Его длина 5 метров, а ширина 2 метра. Найди площадь бревна.",
        "На небе летят 5 птиц, а за ними еще 12. Сколько всего птиц?",
        "Мы набрали 18 литров воды. В одном ведре помещается 6 литров. Сколько ведер нам понадобится?"
    };
    private string[] beachAnswers = { "10", "17", "3" };

    private string[] forestTasks = {
        "Озеро имеет форму прямоугольника. Длина 8 м, ширина 4 м. Найди площадь озера.",
        "На левой пальме 12 кокосов, а на правой на 5 меньше. Сколько кокосов на двух пальмах?",
        "Нам нужно 50 метров лиан. Мы нашли три куска по 12 метров. Сколько метров лиан еще нужно найти?"
    };
    private string[] forestAnswers = { "32", "19", "14" };

    private string[] rockTasks = {
        "Кратер вулкана имеет радиус 4 метра. Найди площадь (π=3).",
        "Лава течет со скоростью 3 м/с. До лагеря 60 метров. Сколько секунд у нас есть?",
        "Нам нужно построить стену из камней. Один камень весит 5 кг. Сколько камней мы сможем унести за раз, если можем поднять не больше 40 кг?"
    };
    private string[] rockAnswers = { "48", "20", "8" };

    // Подсказки
    private string[] beachHints = {
        "Площадь прямоугольника = длина × ширина. Умножь 5 на 2.",
        "Просто сложи всех птиц: 5 + 12.",
        "Раздели общий объем на объем одного ведра: 18 / 6."
    };

    private string[] forestHints = {
        "Площадь = длина × ширина. Умножь 8 на 4.",
        "Сначала найди, сколько на правой пальме (12 - 5), а потом сложи с левой.",
        "Сначала найди, сколько метров в трех кусках (12 × 3), а потом вычти из 50."
    };

    private string[] rockHints = {
        "Площадь круга = π × r². То есть 3 × 4 × 4.",
        "Время = расстояние / скорость. Раздели 60 на 3.",
        "Раздели общий вес (40) на вес одного камня (5)."
    };

    void Start()
    {
        currentLocation = PlayerPrefs.GetString("CurrentLocation", "Beach");

        // Настраиваем фон
        if (currentLocation == "Beach") backgroundImage.sprite = beachSprite;
        else if (currentLocation == "Forest") backgroundImage.sprite = forestSprite;
        else if (currentLocation == "Volcano") backgroundImage.sprite = rockSprite;

        // Прячем кнопку финиша
        finishButtonObject.SetActive(false);
        hintTextObject.SetActive(false);
        answerInputObject.SetActive(true);
        submitButtonObject.SetActive(true);
        backButtonObject.SetActive(true);

        LoadTask();
    }

    void LoadTask()
    {
        if (currentLocation == "Beach")
        {
            if (currentTaskIndex < beachTasks.Length)
                taskText.text = beachTasks[currentTaskIndex];
            else
                EndLocation();
        }
        else if (currentLocation == "Forest")
        {
            if (currentTaskIndex < forestTasks.Length)
                taskText.text = forestTasks[currentTaskIndex];
            else
                EndLocation();
        }
        else if (currentLocation == "Volcano")
        {
            if (currentTaskIndex < rockTasks.Length)
                taskText.text = rockTasks[currentTaskIndex];
            else
                EndLocation();
        }

        // Скрываем подсказку
        hintTextObject.SetActive(false);
        answerInput.text = "";
    }

    void EndLocation()
    {
        // Когда задачи закончились:
        taskText.text = "Все задачи решены! Молодец!";
        PlayerPrefs.SetInt(currentLocation + "Completed", 1); 
        PlayerPrefs.Save();

        // Прячем поле ввода
        answerInputObject.SetActive(false);
        submitButtonObject.SetActive(false);
        hintButtonObject.SetActive(false);
        hintTextObject.SetActive(false);
        backButtonObject.SetActive(false);

        // Показываем кнопку на карту
        finishButtonObject.SetActive(true);
    }

    public void CheckAnswer()
    {
        string userAnswer = answerInput.text.Trim();
        string correctAnswer = "";

        if (currentLocation == "Beach" && currentTaskIndex < beachAnswers.Length) correctAnswer = beachAnswers[currentTaskIndex];
        else if (currentLocation == "Forest" && currentTaskIndex < forestAnswers.Length) correctAnswer = forestAnswers[currentTaskIndex];
        else if (currentLocation == "Volcano" && currentTaskIndex < rockAnswers.Length) correctAnswer = rockAnswers[currentTaskIndex];

        if (userAnswer == correctAnswer)
        {
            Debug.Log("Правильно!");
            currentTaskIndex++;
            LoadTask();
        }
        else
        {
            Debug.Log("Неправильно. Попробуй еще раз.");
        }
    }

    public void ShowHint()
    {
        string hint = "";
        if (currentLocation == "Beach" && currentTaskIndex < beachHints.Length) hint = beachHints[currentTaskIndex];
        else if (currentLocation == "Forest" && currentTaskIndex < forestHints.Length) hint = forestHints[currentTaskIndex];
        else if (currentLocation == "Volcano" && currentTaskIndex < rockHints.Length) hint = rockHints[currentTaskIndex];

        if (hint != "")
        {
            hintTextObject.GetComponent<TextMeshProUGUI>().text = hint;
            hintTextObject.SetActive(true); 
        }
    }
}