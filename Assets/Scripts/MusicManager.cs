using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    private bool isMuted = false;

    public TextMeshProUGUI soundButtonText; 

    void Awake()
    {
        // Если музыка уже играет
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleSound()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не найден на AudioManager!");
            return;
        }

        isMuted = !isMuted; 
        audioSource.mute = isMuted;

        // Меняем текст на кнопке
        if (soundButtonText != null)
        {
            soundButtonText.text = isMuted ? "Звук: ВЫКЛ" : "Звук: ВКЛ";
        }

        Debug.Log("Звук выключен? " + isMuted);
    }
}