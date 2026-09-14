using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Assets.Scripts.Combat.Interfaces
{
    //more input -> more enum
    public enum CombatInputAction { Confirm, Parry}
    public interface IMovementInputProvider
    {
        public event Action<Vector2> OnMoveInput;
        public event Action OnJumpPressed;
    }

    public interface ICombatInputProvider
    {
        public event Action<CombatInputAction> OnActionPressed;
    }
}
