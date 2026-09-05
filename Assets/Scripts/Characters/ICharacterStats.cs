using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Characters
{
    public interface ICharacterStats
    {
        public int CurrentHP { get;}
        public int MaxHP { get;}
        public int Speed { get;}
        public int GetEffectiveSpeed();
    }
}
