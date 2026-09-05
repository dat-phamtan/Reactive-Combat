using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Core
{
    public interface ITurnManager
    {
        public void RebuildQueue();
        public void NextTurn();
        
    }
}
