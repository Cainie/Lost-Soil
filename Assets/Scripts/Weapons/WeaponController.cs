namespace Weapons
{
    using System;
    using UnityEngine;
    
    [RequireComponent(typeof(Weapon))]
    public class WeaponController : MonoBehaviour
    {
        public event Action<WeaponType> OnWeaponShot;
        
        private bool _isShootButtonPressed;
        private Weapon _weapon;
        

        private void Awake()
        {
            GetReferences();
            SubscribeToEvents();
        }

        private void GetReferences()
        {
            _weapon = gameObject.GetComponent<Weapon>(); 
        }

        private void SubscribeToEvents()
        {
            _weapon.OnWeaponShot += Weapon_OnWeaponShot;
        }

        private void Update()
        {
            ProcessInput();    
            if (_isShootButtonPressed)
            {
                _weapon.TryShoot();
            }
        }

        private void ProcessInput()
        {
            _isShootButtonPressed = Input.GetButtonDown("Fire1");
        }

        private void Weapon_OnWeaponShot(WeaponType weaponType)
        {
            OnWeaponShot?.Invoke(weaponType);
        }
    }
}
