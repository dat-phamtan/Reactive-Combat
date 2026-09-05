using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Characters
{
    public interface IDamageable
    {
        public void TakeDamage(int amount);
    }
}
