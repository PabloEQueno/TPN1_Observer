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

        // ¡AÑADIMOS EL UPDATE! Esto hace que el tiempo y el miedo avancen en tiempo real
        private void Update()
        {
            // Acumulamos el tiempo de la partida
            ElapsedSeconds += Time.deltaTime;

            // Simulamos el crecimiento del miedo por tiempo: sube 1 punto cada 2 segundos.
            // (Si en tu 'FearProgressionSO' hay otra lógica, luego la adaptas).
            int calculatedFear = Mathf.FloorToInt(ElapsedSeconds / 2f);
            CurrentFearValue = Mathf.Clamp(calculatedFear, 0, 100);

            // Buscamos el rango actual usando tu ScriptableObject
            if (progression != null)
            {
                CurrentRange = progression.GetRange(CurrentFearValue);
            }

            // Notificamos automáticamente al HUDController (y a los demás sistemas)
            NotifyObservers();
        }

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