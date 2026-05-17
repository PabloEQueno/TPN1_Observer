using System.Collections.Generic;
using TopDownSurvivors.Data;
using UnityEngine;

namespace TopDownSurvivors.Fear
{
    public sealed class FearTimerManager : MonoBehaviour
    {
        [SerializeField] private FearProgressionSO progression;

        private readonly List<IFearObserver> observers = new();

        public float ElapsedSeconds { get; private set; }
        public int CurrentFearValue { get; private set; }
        public FearRangeSO CurrentRange { get; private set; }

        public void Register(IFearObserver observer)
        {
            if (observer != null && !observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unregister(IFearObserver observer)
        {
            if (observer != null)
            {
                observers.Remove(observer);
            }
        }

        public void SetFearForStructurePreview(int fearValue)
        {
            CurrentFearValue = Mathf.Clamp(fearValue, 0, 100);
            CurrentRange = progression != null ? progression.GetRange(CurrentFearValue) : null;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            FearContext context = new(ElapsedSeconds, CurrentFearValue, CurrentRange);

            foreach (IFearObserver observer in observers)
            {
                observer.OnFearChanged(context);
            }
        }
    }
}
