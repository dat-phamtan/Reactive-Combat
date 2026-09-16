using Assets.Scripts.Combat.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Combat.Implements
{
    public class CombatInputProvider : ICombatInputProvider, IDisposable
    {
        private readonly InputAction _confirm;
        private readonly InputAction _parry;
        private Action<InputAction.CallbackContext> _onConfirm;
        private Action<InputAction.CallbackContext> _onParry;

        public event Action<CombatInputAction> OnActionPressed;

        public CombatInputProvider(InputActionAsset inputActions)
        {
            var combatMap = inputActions.FindActionMap("Combat");

            _confirm = combatMap.FindAction("ConfirmTiming");
            _parry = combatMap.FindAction("Parry");

            _onConfirm = _ => OnActionPressed?.Invoke(CombatInputAction.Confirm);
            _onParry = _ => OnActionPressed?.Invoke(CombatInputAction.Parry);

            _confirm.performed += _onConfirm;
            _parry.performed += _onParry;
        }
        
        public void Dispose()
        {
            _confirm.performed -= _onConfirm;
            _parry.performed -= _onParry;
        }
    }
}
