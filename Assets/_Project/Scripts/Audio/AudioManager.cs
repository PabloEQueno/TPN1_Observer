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

        public AudioClip ButtonHoverClip => buttonHoverClip;
        public AudioClip ButtonClickClip => buttonClickClip;
        public AudioClip EnemyDeathClip => enemyDeathClip;

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

        private void OnEnable()
        {
            GameManager.OnStateChanged += HandleGameStateChanged;
        }

        private void OnDisable()
        {
            GameManager.OnStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.Playing:

                    if (musicSource.clip == gameLoopMusic)
                    {
                        musicSource.volume = 0.8f; 
                    }
                    else
                    {
                        musicSource.volume = 0.8f;
                        ChangeMusic(gameLoopMusic);
                    }
                    break;

                case GameState.Paused:
                    musicSource.volume = 0.2f; 
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