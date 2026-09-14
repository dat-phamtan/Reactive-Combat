using Assets.Scripts.Combat.Implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Combat.Interfaces
{
    // catch player interaction 
    public interface ITimingSystem
    {
        public bool IsWindowOpen { get; }
        public event Action<TimingResult> OnResult;

        public void OpenWindow(TimingWindowConfig timeConfig);
        public void RegisterInput(float elapsedSinceWindowOpen);
        public void CloseWindow(float elapsedSinceWindowOpen);
    }
}
