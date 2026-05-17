using TopDownSurvivors.Combat;
using UnityEngine;

namespace TopDownSurvivors.Progression
{
    [CreateAssetMenu(fileName = "Power", menuName = "Top Down Survivors/Progression/Power")]
    public sealed class PowerSO : ScriptableObject, IPowerEffect
    {
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField] private float damageBonus;
        [SerializeField] private float shotsPerSecondBonus;

        public string Id => id;
        public string DisplayName => displayName;
        public string Description => description;
        public Sprite Icon => icon;
        public float DamageBonus => damageBonus;
        public float ShotsPerSecondBonus => shotsPerSecondBonus;

        public void ApplyTo(WeaponStats weaponStats)
        {
            if (weaponStats == null)
            {
                return;
            }

            weaponStats.AddDamage(damageBonus);
            weaponStats.AddShotsPerSecond(shotsPerSecondBonus);
        }
    }
}
