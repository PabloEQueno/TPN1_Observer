using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class HUDManager : MonoBehaviour
    {
        [SerializeField] private HealthView healthView;
        [SerializeField] private FearTimerView fearTimerView;
        [SerializeField] private FearLevelView fearLevelView;
        [SerializeField] private XPBarView xpBarView;
        [SerializeField] private LevelView levelView;
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private KillCounterView killCounterView;

        public HealthView HealthView => healthView;
        public FearTimerView FearTimerView => fearTimerView;
        public FearLevelView FearLevelView => fearLevelView;
        public XPBarView XPBarView => xpBarView;
        public LevelView LevelView => levelView;
        public ScoreView ScoreView => scoreView;
        public KillCounterView KillCounterView => killCounterView;
    }
}
