using Assets.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Combat
{
    public interface ICombatCommand
    {
        public event Action OnCommandCompleted;
        public void Execute(ICharacterEntity caster, List<ICharacterEntity> targets);
    }
}
