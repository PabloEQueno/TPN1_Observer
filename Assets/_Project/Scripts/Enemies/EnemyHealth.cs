using TopDownSurvivors.Combat;
using UnityEngine;


namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyHealth : DamageReceiver
    {
        [SerializeField] private EnemyDeathHandler deathHandler;

        protected override void Awake()
        {
            base.Awake();
            if (deathHandler == null) deathHandler = GetComponent<EnemyDeathHandler>();
        }

        private void Update()
        {
            if (!IsAlive && deathHandler != null)
            {
                deathHandler.HandleDeath(); 
            }
        }
    }
}