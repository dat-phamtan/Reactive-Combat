using Assets.Scripts.Combat.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Combat.Implements
{
    public class CombatInputProvider : ICombatInputProvider, IDisposable
    {
        private InputAction _confirm;
        private InputAction _parry;
        public event Action<CombatInputAction> OnActionPressed;

        public CombatInputProvider(InputActionAsset inputActions)
        {
            var combatMap = inputActions.FindActionMap("Combat");

            _confirm = combatMap.FindAction("ConfirmTiming");
            _parry = combatMap.FindAction("Parry");

            _confirm.performed += (action) => OnActionPressed?.Invoke(CombatInputAction.Confirm);
            _parry.performed += (action) => OnActionPressed?.Invoke(CombatInputAction.Parry);
        }
        
        public void Dispose()
        {
            _confirm.performed -= (action) => OnActionPressed?.Invoke(CombatInputAction.Confirm);
            _parry.performed -= (action) => OnActionPressed?.Invoke(CombatInputAction.Parry);
        }
    }
}
