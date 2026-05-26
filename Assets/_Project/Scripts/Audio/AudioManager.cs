using UnityEngine;
using TopDownSurvivors.Core; 

namespace TopDownSurvivors.Audio
{
    public sealed class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Fuentes de Audio (Audio Sources)")]
        [SerializeField] private AudioSource sfxSource;   
        [SerializeField] private AudioSource uiSource;    
        [SerializeField] private AudioSource musicSource; 

        [Header("Clips de Música")]
        [SerializeField] private AudioClip mainMenuMusic;
        [SerializeField] private AudioClip gameLoopMusic;
        [SerializeField] private AudioClip pauseMenuMusic;
        [SerializeField] private AudioClip levelUpMusic; 

        [Header("Clips de Interfaz (UI)")]
        [SerializeField] private AudioClip buttonHoverClip;
        [SerializeField] private AudioClip buttonClickClip;

        [Header("Clips de Combate")]
        [SerializeField] private AudioClip playerShootClip;
        [SerializeField] private AudioClip enemyDeathClip;
        
        [Header("Configuración de Volumen Base (0 a 1)")]
        private const string MusicVolKey = "Volume_Music";
        private const string SfxVolKey = "Volume_SFX";
        private const string UiVolKey = "Volume_UI";

        public AudioClip ButtonHoverClip => buttonHoverClip;
        public AudioClip ButtonClickClip => buttonClickClip;
        public AudioClip EnemyDeathClip => enemyDeathClip;

        public float GetMusicVolume() => PlayerPrefs.GetFloat(MusicVolKey, 0.7f);
        public float GetSFXVolume() => PlayerPrefs.GetFloat(SfxVolKey, 0.7f);
        public float GetUIVolume() => PlayerPrefs.GetFloat(UiVolKey, 0.7f);
        
        private void Start()
        {
            SetMusicVolume(PlayerPrefs.GetFloat(MusicVolKey, 0.7f));
            SetSFXVolume(PlayerPrefs.GetFloat(SfxVolKey, 0.7f));
            SetUIVolume(PlayerPrefs.GetFloat(UiVolKey, 0.7f));
        }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        public void SetMusicVolume(float value)
        {
            if (musicSource == null) return;
            musicSource.volume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(MusicVolKey, musicSource.volume);
        }

        public void SetSFXVolume(float value)
        {
            if (sfxSource == null) return;
            sfxSource.volume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(SfxVolKey, sfxSource.volume);
        }

        public void SetUIVolume(float value)
        {
            if (uiSource == null) return;
            uiSource.volume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(UiVolKey, uiSource.volume);
        }

      private void OnEnable()
{
    UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
}

private void OnDisable()
{
    UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    if (GameManager.Instance != null)
        GameManager.OnStateChanged -= HandleGameStateChanged;
}
private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
{
    if (GameManager.Instance != null)
    {
        GameManager.OnStateChanged -= HandleGameStateChanged;
        GameManager.OnStateChanged += HandleGameStateChanged;
        
        HandleGameStateChanged(GameManager.Instance.CurrentState);
    }
}

        private void HandleGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.Playing:
         		  	ChangeMusic(gameLoopMusic);
         		  	musicSource.volume = 0.5f;
          			break;

                case GameState.Paused:
					ChangeMusic(pauseMenuMusic);
                    musicSource.volume = 0.4f; 
                    break;

                case GameState.MainMenu:
					ChangeMusic(mainMenuMusic);
                    musicSource.volume = 0.4f; 
                    break;

                case GameState.LevelUp:
                    
                    musicSource.volume = 0.2f; 
                    break;

                case GameState.GameOver:

                    musicSource.volume = 0f;
                    musicSource.Stop();
                    break;
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (clip != null && sfxSource != null) sfxSource.PlayOneShot(clip);
        }

        public void PlayUISound(AudioClip clip)
        {
            if (clip != null && uiSource != null) uiSource.PlayOneShot(clip);
        }

        public void PlayShoot()
        {
            if (playerShootClip != null && sfxSource != null) sfxSource.PlayOneShot(playerShootClip);
        }

        private void ChangeMusic(AudioClip newMusic)
        {
            if (musicSource == null) return;
            if (musicSource.clip == newMusic) return; 

            musicSource.Stop();
            musicSource.clip = newMusic;
            
            if (newMusic != null)
            {
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }
}