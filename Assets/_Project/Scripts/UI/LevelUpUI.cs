using UnityEngine;
using TopDownSurvivors.Combat;
using TopDownSurvivors.Player;
using TopDownSurvivors.Menus;

namespace TopDownSurvivors.UI
{
    public sealed class LevelUpUI : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        [SerializeField] private LevelUpMenuController menuController;

        private WeaponStats playerWeapon;
        private PlayerHealth playerHealth;

        private void Awake()
        {
            if (menuController == null) menuController = GetComponentInParent<LevelUpMenuController>();
            
            playerWeapon = FindFirstObjectByType<WeaponStats>();
            playerHealth = FindFirstObjectByType<PlayerHealth>();
        }

        public void Show()
        {
            if (root != null) root.SetActive(true);
        }

        public void Hide()
        {
            if (root != null) root.SetActive(false);
        }

      

        public void Opcion_MejorarDanio()
        {
            if (playerWeapon != null)
            {
                playerWeapon.AddDamage(5f); 
            }
            FinalizarSeleccion();
        }

        public void Opcion_MejorarCadencia()
        {
            if (playerWeapon != null)
            {
                playerWeapon.AddShotsPerSecond(1f); 
            }
            FinalizarSeleccion();
        }

        public void Opcion_CurarVida()
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(-playerHealth.MaxHealth); 
            }
            FinalizarSeleccion();
        }

        private void FinalizarSeleccion()
        {
            Hide();
            if (menuController != null)
            {
                menuController.ChoosePower(null); 
            }
        }
    }
}