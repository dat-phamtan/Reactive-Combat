using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Characters
{
    public interface ICharacterEntity : ICharacterStats, IDamageable
    {
        public string Id { get; }
        public bool IsPlayerControlled { get; }
    }
}
