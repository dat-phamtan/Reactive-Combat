using Assets.Scripts.Characters;
using Assets.Scripts.Combat.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.AI
{
    public interface IBossState
    {
        public void EnterState(ICharacterEntity boss);
        public ICombatCommand DecideNextAction(ICharacterEntity boss, List<ICharacterEntity> players);
        public void ExitState();
    }
}
