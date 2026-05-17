using TopDownSurvivors.Fear;
using UnityEngine;

namespace TopDownSurvivors.Lighting
{
    public sealed class FearLightingSystem : MonoBehaviour, IFearObserver
    {
        [SerializeField] private Light sceneLight;
        [SerializeField] private Gradient fearColorGradient;
        [SerializeField, Min(0f)] private float minimumIntensity = 0.3f;
        [SerializeField, Min(0f)] private float maximumIntensity = 1f;

        public Light SceneLight => sceneLight;
        public Gradient FearColorGradient => fearColorGradient;
        public float MinimumIntensity => minimumIntensity;
        public float MaximumIntensity => maximumIntensity;

        public void OnFearChanged(FearContext context)
        {
        }
    }
}
