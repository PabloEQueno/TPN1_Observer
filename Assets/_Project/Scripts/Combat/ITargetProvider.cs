using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public interface ITargetProvider
    {
        Transform CurrentTarget { get; }
    }
}
