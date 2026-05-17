using TopDownSurvivors.Data;
using UnityEngine;

namespace TopDownSurvivors.Data
{
    [CreateAssetMenu(fileName = "AudioFearConfig", menuName = "Top Down Survivors/Audio/Fear Audio Config")]
    public sealed class AudioFearConfigSO : ScriptableObject
    {
        [SerializeField] private FearRangeSO fearRange;
        [SerializeField] private AudioClip music;
        [SerializeField] private AudioClip ambience;
        [SerializeField, Range(0f, 1f)] private float musicVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float ambienceVolume = 1f;

        public FearRangeSO FearRange => fearRange;
        public AudioClip Music => music;
        public AudioClip Ambience => ambience;
        public float MusicVolume => musicVolume;
        public float AmbienceVolume => ambienceVolume;
    }
}
