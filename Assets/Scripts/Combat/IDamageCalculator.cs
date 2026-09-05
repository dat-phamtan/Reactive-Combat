using Assets.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Combat
{
    public interface IDamageCalculator
    {
        public int CalculateDamage(ICharacterEntity attacker, ICharacterEntity defender);
    }
}
