using TopDownSurvivors.Combat;
using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerHealth : DamageReceiver
    {
        [SerializeField] private bool triggerGameOverOnDeath = true;

        public bool TriggerGameOverOnDeath => triggerGameOverOnDeath;
    }
}
