using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource musicSource;

    public AudioClip menuMusic;
    public AudioClip outdoorMusic;
    public AudioClip quizMusic;
    public AudioClip indoorMusic;

    private string currentScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        currentScene = sceneName;

        switch (sceneName)
        {
            case "MainMenu":
                PlayClip(menuMusic);
                break;
            case "OUTDOOR":
                PlayClip(outdoorMusic);
                break;
            case "QuizScene":
                PlayClip(quizMusic);
                break;
            case "IndoorRoom":
                PlayClip(indoorMusic);
                break;
            default:
                musicSource.Stop();
                break;
        }
    }

    void PlayClip(AudioClip clip)
    {
        if (musicSource.clip == clip) return; // already playing
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}
