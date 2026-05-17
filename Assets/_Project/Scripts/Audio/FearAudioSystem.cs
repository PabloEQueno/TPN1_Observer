using System.Collections.Generic;
using TopDownSurvivors.Data;
using TopDownSurvivors.Fear;
using UnityEngine;

namespace TopDownSurvivors.Audio
{
    public sealed class FearAudioSystem : MonoBehaviour, IFearObserver
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource ambienceSource;
        [SerializeField] private List<AudioFearConfigSO> configs = new();

        public AudioSource MusicSource => musicSource;
        public AudioSource AmbienceSource => ambienceSource;
        public IReadOnlyList<AudioFearConfigSO> Configs => configs;

        public void OnFearChanged(FearContext context)
        {
        }
    }
}
